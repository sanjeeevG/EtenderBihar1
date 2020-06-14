using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ETB.Core.Entities;
using ETB.Utilities;
using ETB.WebApp.Models;
using ETB.WebApp.Services;
using ETB.WebApp.Utilities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Serilog;

namespace ETB.WebApp.Controllers
{
    public class UserInfoController : Controller
    {
        private readonly IOptions<ApplicationSettings> _appSettings;
        private readonly DataProtector _dataProtector;
        private readonly EncryptionDecryption _encryptDecrypt;
        private readonly ISession _session;
        private readonly HttpRequest _request;
        private readonly UserInfoService _userInfoService;
        private readonly DistrictService _districtSerice;
        private readonly ServiceService _serviceService;
        private readonly UserSubscriptionService _userSubscriptionService;
        private readonly EmailSenderService _emailSenderService;
        private readonly SMSSenderService _smsSenderService;


        public UserInfoController(IOptions<ApplicationSettings> appSettings,
            DataProtector dataProtector,
            EncryptionDecryption encryptDecrypt,
            IHttpContextAccessor httpContextAccessor,
            UserInfoService userInfoService,
            DistrictService districtSerice,
            ServiceService serviceService,
            UserSubscriptionService userSubscriptionService,
        EmailSenderService emailSenderService,
            SMSSenderService smsSenderService)
        {
            _appSettings = appSettings;
            _dataProtector = dataProtector;
            _encryptDecrypt = encryptDecrypt;
            //_protector = protectionProvider.CreateProtector(GetType().FullName);
            _session = httpContextAccessor.HttpContext.Session;
            _request = httpContextAccessor.HttpContext.Request;
            _userInfoService = userInfoService;
            _districtSerice = districtSerice;
            _serviceService = serviceService;
            _userSubscriptionService = userSubscriptionService;
            _emailSenderService = emailSenderService;
            _smsSenderService = smsSenderService;
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = $"{_appSettings.Value.AppTitle}-{Subtitle.UserList}";
            var noOfRowlst = _appSettings.Value.NoOfRowsOptions.Split(',').ToList();
            var rowOption = _appSettings.Value.DefaultOptionRowSel;
            List<SelectListItem> NoOfRowsSelItemLst = new List<SelectListItem>();
            foreach (var x in noOfRowlst)
            {
                NoOfRowsSelItemLst.Add(new SelectListItem() { Value = x, Text = x, Selected = (x == rowOption) });
            }

            var indexVM = new UserInfoIndexViewModel()
            {
                Districts = await _districtSerice.GetDistrictSelectList(),
                NoOfRows = NoOfRowsSelItemLst
            };
            return View(indexVM);
        }


        public IActionResult ResetPassword()
        {
            ViewData["Title"] = $"{_appSettings.Value.AppTitle}-{Subtitle.ResetPass}";
            string encyptedData = string.Empty;
            if (_request.Query.ContainsKey("k"))
                encyptedData = _request.Query["k"];


            var changePassVM = new ChangePassViewModel();
            ViewBag.showcontrols = false;
            if (!string.IsNullOrEmpty(encyptedData))
            {
                var deEncyptedText = _dataProtector.Decrypt(encyptedData);
                //format
                //$"ETB~{UserId}~{email}~{DateTime.Now}-{Value.ForgotPassLinkExpiration}";
                var arrValues = deEncyptedText.Split("~");
                if (arrValues.Count() > 4)
                {
                    if ((DateTime.Now - DateTime.Parse(arrValues[3])).TotalMinutes > int.Parse(arrValues[4]))
                    {
                        ModelState.AddModelError("", "Token has expired.");

                    }
                    else
                    {
                        ViewBag.showcontrols = true;
                        changePassVM.UserId = _dataProtector.Encrypt(arrValues[1]);
                        changePassVM.Pass = "";
                        return View("ResetPassword", changePassVM);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Token.");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid Token.");
            }
            return View("ResetPassword", changePassVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ChangePassViewModel changePassViewModel)
        {
            try
            {
                ViewBag.showcontrols = true;
                var userid = _dataProtector.Decrypt(changePassViewModel.UserId);
                var result = await _userInfoService.GetUserInfoDetails(userid);
                if (result != null)
                {
                    var uInfo = result.UserInfo;
                    uInfo.Pass = _encryptDecrypt.HashPassword(changePassViewModel.Pass);
                    uInfo.ModificationDate = DateTime.Now;

                    var resultUIUpdate = await _userInfoService.UpdateUserInfo(uInfo.Id, uInfo);

                    if (resultUIUpdate.Status == StatusText.Successful.ToString())
                    {
                        ViewBag.Message = new StatusResult() { Status = StatusText.Info.ToString(), StatusDetail = "Congratulations! Your password has been reset." };
                        return RedirectToAction("Login", "UserInfo");
                    }
                    else
                    {
                        ViewBag.Message = new StatusResult() { Status = StatusText.Error.ToString(), StatusDetail = resultUIUpdate.StatusDetail };
                        ModelState.AddModelError("", resultUIUpdate.StatusDetail);
                        changePassViewModel.Pass = "";
                        changePassViewModel.OldPass = "";
                    }
                }
                else
                {
                    ViewBag.showcontrols = false;
                    ViewBag.Message = new StatusResult() { Status = StatusText.Error.ToString(), StatusDetail = "User Id does not exists." };
                    ModelState.AddModelError("", "User Id does not exists.");
                    changePassViewModel.Pass = "";
                    changePassViewModel.OldPass = "";
                }
                return View("ResetPassword", changePassViewModel);
            }
            catch (Exception ex)
            {
                ViewBag.Message = new StatusResult() { Status = StatusText.UnHandledError.ToString(), StatusDetail = ex.Message };
                Log.Logger.Error(ex.Message);
                ModelState.AddModelError("", ex.Message);
                changePassViewModel.Pass = "";
                changePassViewModel.OldPass = "";
                return View("ResetPassword", changePassViewModel);
            }
        }

        public IActionResult ForgotPassword()
        {
            ViewData["Title"] = $"{_appSettings.Value.AppTitle}-{Subtitle.ForgotPass}";
            var forgotPassVM = new ForgotPassViewModel()
            {
                UserId = string.Empty,
            };
            return View(forgotPassVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPassViewModel forgotPassViewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Please Enter the Data.");
                return View(forgotPassViewModel);
            }
            else
            {
                //find out if the user exists.
                var result = await _userInfoService.GetUserInfoDetails(forgotPassViewModel.UserId);

                if (result != null)
                {
                    var email = result.Email1;
                    var toBeEncryptedText = $"ETB~{forgotPassViewModel.UserId}~{email}~{DateTime.Now}~{_appSettings.Value.ForgotPassLinkExpiration}";
                    var encyptedText = _dataProtector.Encrypt(toBeEncryptedText);
                    var url = $"{_request.Scheme}://{_request.Host.Value}/UserInfo/ResetPassword?k={encyptedText}";

                    try
                    {
                        _emailSenderService.SendForgotPassEmailNotification(forgotPassViewModel.UserId, email, url, "EtenderBihar: Reset Account Password");
                        ViewBag.Message = new StatusResult() { Status = StatusText.Info.ToString(), StatusDetail = "Email sent for resetting account password" };
                    }
                    catch (Exception exemail)
                    {
                        ViewBag.Message = new StatusResult() { Status = StatusText.UnHandledError.ToString(), StatusDetail = exemail.Message };
                        Log.Logger.Error(exemail.Message);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "User Id is not valid.");
                    forgotPassViewModel.UserId = "";
                    return View(forgotPassViewModel);
                }

            }
            return View(forgotPassViewModel);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangeUsersPassword(int id)
        {
            ViewData["Title"] = $"{_appSettings.Value.AppTitle}-{Subtitle.ChangeUserPass}";
            var result = await _userInfoService.GetUserDetailById(id);
            var changePassVM = new ChangeUsersPassViewModel();

            if (result != null)
            {
                changePassVM = new ChangeUsersPassViewModel()
                {
                    UserId = result.UserInfo.UserId,
                    UserIdEncr = _dataProtector.Encrypt(result.UserInfo.UserId),
                    FullName = result.FullName,
                    Pass = ""
                };
            }
            else
            {
                ViewBag.Message = new StatusResult() { Status = StatusText.Error.ToString(), StatusDetail = "This user is either not active or does not exists" };
            }
            return View(changePassVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangeUsersPassword(int id, ChangeUsersPassViewModel changePassViewModel)
        {
            try
            {
                var userId = _dataProtector.Decrypt(changePassViewModel.UserIdEncr);

                if (userId == changePassViewModel.UserId)
                {

                    var result = await _userInfoService.GetUserInfoDetails(userId);

                    if (result != null)
                    {

                        var uInfo = result.UserInfo;
                        uInfo.Pass = _encryptDecrypt.HashPassword(changePassViewModel.Pass);
                        uInfo.ModificationDate = DateTime.Now;

                        var resultUIUpdate = await _userInfoService.UpdateUserInfo(uInfo.Id, uInfo);

                        if (resultUIUpdate.Status == StatusText.Successful.ToString())
                        {
                            return RedirectToAction("Index", "UserInfo");
                        }
                        else
                        {
                            ModelState.AddModelError("", resultUIUpdate.StatusDetail);
                            changePassViewModel.Pass = "";
                            return View("ChangeUsersPassword", changePassViewModel);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Cannot change the password, wong user!");
                        changePassViewModel.Pass = "";
                        return View("ChangeUsersPassword", changePassViewModel);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "User has been altered!!");
                    changePassViewModel.Pass = "";
                    return View("ChangeUsersPassword", changePassViewModel);
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                ModelState.AddModelError("", ex.Message);
                changePassViewModel.Pass = "";
                return View("ChangeUsersPassword", changePassViewModel);
            }
        }

        [Authorize(Roles = "Admin, Operator, Subscriber")]
        public IActionResult ChangeYourPassword()
        {
            ViewData["Title"] = $"{_appSettings.Value.AppTitle}-{Subtitle.ChangeYourPass}";
            var changePassVM = new ChangePassViewModel()
            {
                UserId = _dataProtector.Encrypt(_session.GetString("UserId")),
                FullName = _session.GetString("Name"),
                OldPass = "",
                Pass = ""
            };
            return View(changePassVM);
        }

        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Operator, Subscriber")]
        public async Task<IActionResult> ChangeUserPass(ChangePassViewModel changePassViewModel)
        {
            try
            {
                var userId = _dataProtector.Decrypt(changePassViewModel.UserId);

                var result = await _userInfoService.GetUserInfoDetails(userId);

                if (result != null)
                {
                    if (!_encryptDecrypt.VerifyHashedPassword(result.UserInfo.Pass, changePassViewModel.OldPass))
                    {
                        ModelState.AddModelError("", "Wrong old password!");
                        changePassViewModel.Pass = "";
                        changePassViewModel.OldPass = "";
                        return View("ChangeYourPassword", changePassViewModel);
                    }
                    else
                    {
                        var uInfo = result.UserInfo;
                        uInfo.Pass = _encryptDecrypt.HashPassword(changePassViewModel.Pass);
                        uInfo.ModificationDate = DateTime.Now;

                        var resultUIUpdate = await _userInfoService.UpdateUserInfo(uInfo.Id, uInfo);

                        if (resultUIUpdate.Status == StatusText.Successful.ToString())
                        {
                            return RedirectToAction("Index2", "Tenders");
                        }
                        else
                        {
                            ModelState.AddModelError("", resultUIUpdate.StatusDetail);
                            changePassViewModel.Pass = "";
                            changePassViewModel.OldPass = "";
                            return View("ChangeYourPassword", changePassViewModel);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Cannot change the password, wong user!");
                    changePassViewModel.Pass = "";
                    changePassViewModel.OldPass = "";
                    return View("ChangeYourPassword", changePassViewModel);
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                ModelState.AddModelError("", ex.Message);
                changePassViewModel.Pass = "";
                changePassViewModel.OldPass = "";
                return View("ChangeYourPassword", changePassViewModel);
            }
        }

        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> DeActivateUser(int id)
        {
            try
            {
                var result = await _userInfoService.DeactivateUser(id);

                if (result.Status == StatusText.Successful.ToString())
                {
                    return Json(new { datas = "", status = "Successful", message = "" });
                }
                else
                {
                    return Json(new { datas = "", status = "Error", message = result.StatusDetail });
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return Json(new { datas = "", status = "Error", error = ex.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> ActivateUser(int id)
        {
            try
            {
                var result = await _userInfoService.ActivateUser(id);

                if (result.Status == StatusText.Successful.ToString())
                {
                    return Json(new { datas = "", status = "Successful", message = "" });
                }
                else
                {
                    return Json(new { datas = "", status = "Error", message = result.StatusDetail });
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return Json(new { datas = "", status = "Error", error = ex.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> DeleteUser(int id)
        {
            try
            {
                var result = await _userInfoService.DeleteUser(id);

                if (result.Status == StatusText.Successful.ToString())
                {
                    return Json(new { datas = "", status = "Successful", message = "" });
                }
                else
                {
                    return Json(new { datas = "", status = "Error", message = result.StatusDetail });
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return Json(new { datas = "", status = "Error", error = ex.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> GetUserDetails(UserInfoIndexViewModel filterCond)
        {
            try
            {
                var userDetails = await _userInfoService.GetUserDetails();

                IList<UserDetail> filteredData = userDetails;

                if (!string.IsNullOrEmpty(filterCond.IsActive))
                {
                    if (filterCond.IsActive == "N")
                    {
                        filteredData = filteredData.Where(x => (int)x.IsActive == (int)IsActive.N).ToList();
                    }
                    else
                    {
                        filteredData = filteredData.Where(x => (int)x.IsActive == (int)IsActive.Y).ToList();
                    }
                }

                if (!string.IsNullOrEmpty(filterCond.IsUpdated))
                    filteredData = filteredData.Where(x => ((int)x.IsDetailUpdated).ToString() == filterCond.IsUpdated).ToList();

                if (!string.IsNullOrEmpty(filterCond.FullName))
                    filteredData = filteredData.Where(x => x.FullName.ToLower().Contains(filterCond.FullName.Trim().ToLower())).ToList();

                if (!string.IsNullOrEmpty(filterCond.ContactNo1))
                    filteredData = filteredData.Where(x => x.ContactNo1.ToLower().EndsWith(filterCond.ContactNo1.Trim())).ToList();

                if (!string.IsNullOrEmpty(filterCond.City))
                    filteredData = filteredData.Where(x => x.City.EmptyIfNull().ToLower().Contains(filterCond.City.Trim().ToLower())).ToList();

                if (!string.IsNullOrEmpty(filterCond.District))
                    filteredData = filteredData.Where(x => x.District.EmptyIfNull() == filterCond.District).ToList();

                if (!string.IsNullOrEmpty(filterCond.ModificationDate))
                {
                    DateTime enteredDate = DateTime.Parse(filterCond.ModificationDate);
                    filteredData = filteredData.Where(x => x.ModificationDate.Value.Date.CompareTo(enteredDate.Date) == 0).ToList();
                }
                var orderedData = filteredData.OrderByDescending(x => x.Id);

                //var filteredData = userDetails;
                return Json(new { datas = orderedData, tcount = userDetails.Count(), rcount = orderedData.Count(), status = "Successful", error = "" });
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return Json(new { datas = new List<Tender>(), tcount = 0, rcount = 0, status = "Error", error = ex.Message });
            }

        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewData["Title"] = $"{_appSettings.Value.AppTitle}-{Subtitle.Register}";
            var registerViewModel = new RegisterViewModel();
            registerViewModel.Salutation = Salutations.Mr.ToString();
            registerViewModel.UserRole = UserRole.Subscriber;

            return View(registerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                //TempData["notice"] = new CustomStatus() { status = TanHelper.Utils.statusType.error.ToString(), statustext = $"Associtated to Station field is required." };
                ModelState.AddModelError("", "Please Enter Data.");
                return View(registerViewModel);
            }
            else
            {
                var isAlreadyExists = await _userInfoService.IsUserIdAlreayExists(registerViewModel.UserId);

                if (isAlreadyExists)
                {
                    TempData.Put("notify", new StatusResult() { Status = StatusText.Info.ToString(), StatusDetail = "User already exists." });
                    ModelState.AddModelError("UserId", "User already exists.");
                    ModelState.AddModelError("", "User already exists.");
                    return View(registerViewModel);
                }

                if (registerViewModel.ContactNo1.StartsWith("+91"))
                {
                    string msg = "Phone no. should not start with +91";
                    TempData.Put("notify", new StatusResult() { Status = StatusText.Info.ToString(), StatusDetail = msg });
                    ModelState.AddModelError("ContactNo1", msg);
                    ModelState.AddModelError("", msg);
                    return View(registerViewModel);
                }

                //Pass = _dataProtector.Encrypt(registerViewModel.Pass),
                var userInfo = new UserInfo()
                {
                    UserId = registerViewModel.UserId,
                    Pass = _encryptDecrypt.HashPassword(registerViewModel.Pass),
                    Allow = IsActive.Y,
                    UserRole = registerViewModel.UserRole,
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now
                };
                var names = registerViewModel.FullName.Split(' ');
                var fname = names[0];
                var lname = names.Count() == 1 ? string.Empty : names[names.Count() - 1];
                var mname = registerViewModel.FullName.Replace(fname, "").Trim();
                if (!string.IsNullOrEmpty(lname))
                {
                    mname = mname.Replace(lname, "").Trim();
                }

                // Save today's date.
                var today = DateTime.Today;
                // Calculate the age.
                var age = today.Year - registerViewModel.DOB.Value.Year;
                // Go back to the year the person was born in case of a leap year
                if (registerViewModel.DOB.Value.Date > today.AddYears(-age)) age--;

                var userDetail = new UserDetail()
                {
                    Salutation = registerViewModel.Salutation,
                    FName = fname,
                    MName = mname,
                    LName = lname,
                    DOB = registerViewModel.DOB,
                    Age = age,
                    ContactNo1 = $"{registerViewModel.CountryAreaCode}{registerViewModel.ContactNo1}",
                    Email1 = registerViewModel.Email1,
                    WantEmailNotfi = NotificationRequired.YES,
                    WantWhatsUpNotfi = NotificationRequired.YES,
                    District = string.Empty,
                    Gender = Gender.Male,
                    IsActive = IsActive.Y,
                    IsDetailUpdated = IsRecordUpdated.NO,
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now,
                    UserInfo = userInfo,
                    CreatedBy = userInfo.UserId
                };

                var result = await _userInfoService.RegisterNewUser(userDetail);
                TempData.Put("notify", result);
                if (result.Status == StatusText.Successful.ToString())
                {
                    try
                    {
                        string name = $"{registerViewModel.Salutation} {registerViewModel.FullName}";
                        //var url = _appSettings.Value.LoginPageUrl;
                        var url = $"{(_request.IsHttps?_request.Scheme: "https")}://{_request.Host.Value}/UserInfo/Login";
                        var serviceUrl = $"{(_request.IsHttps ? _request.Scheme : "https")}://{_request.Host.Value}/Services/ServiceView";
                        _emailSenderService.SendCreateAcountEmailNotification(name, registerViewModel.UserId, registerViewModel.Email1, url, serviceUrl, "EtenderBihar: Account Creation confirmation");
                        _smsSenderService.SendCreateAcountSMSNotification(name, registerViewModel.UserId, registerViewModel.ContactNo1, url);
                    }
                    catch (Exception ex)
                    {
                        Log.Logger.Error(ex.Message);
                    }

                    return RedirectToAction("Login");
                }
                else if (result.Status == StatusText.Error.ToString())
                {
                    ModelState.AddModelError("", result.StatusDetail);
                    return View(registerViewModel);
                }
            }
            return View(registerViewModel);
        }


        [HttpGet]
        [Authorize(Roles = "Admin, Operator, Subscriber")]
        public async Task<IActionResult> View(int id)
        {
            var userDetail = await _userInfoService.GetUserDetailById(id);
            var userDetailViewModel = MapToUserDetailModelView(userDetail);

            userDetailViewModel.Districts = await _districtSerice.GetDistrictSelectList();
            return View(userDetailViewModel);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UserDetail(string userId)
        {
            ViewData["Title"] = $"{_appSettings.Value.AppTitle}-{Subtitle.UserDetailEdit}";
            var userDetail = await _userInfoService.GetUserInfoDetails(userId);
            var userDetailViewModel = MapToUserDetailModelView(userDetail);

            userDetailViewModel.Districts = await _districtSerice.GetDistrictSelectList();
            return View(userDetailViewModel);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UserDetailById(int id)
        {
            ViewData["Title"] = $"{_appSettings.Value.AppTitle}-{Subtitle.UserDetailView}";
            var userDetail = await _userInfoService.GetUserDetailById(id);
            var userDetailViewModel = MapToUserDetailModelView(userDetail);

            userDetailViewModel.Districts = await _districtSerice.GetDistrictSelectList();
            return View("UserDetail", userDetailViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UserDetail(int id, IList<IFormFile> photofile, UserDetailModelView userDetailModelView)
        {
            userDetailModelView.Districts = await _districtSerice.GetDistrictSelectList();

            if (!ModelState.IsValid)
            {
                string message = "Please enter required data.";
                TempData.Put("notify", new StatusResult() { Status = StatusText.Error.ToString(), StatusDetail = message });
                ModelState.AddModelError("", message);
                return View(userDetailModelView);
            }
            else
            {
                if (!string.IsNullOrEmpty(userDetailModelView.ContactNo1) &&
                    userDetailModelView.ContactNo1.StartsWith("+91"))
                {
                    string msg = "Contact1 should not start with +91";
                    TempData.Put("notify", new StatusResult() { Status = StatusText.Info.ToString(), StatusDetail = msg });
                    ModelState.AddModelError("ContactNo1", msg);
                    return View(userDetailModelView);
                }
                if (!string.IsNullOrEmpty(userDetailModelView.ContactNo2Mobile) &&
                    userDetailModelView.ContactNo2Mobile.StartsWith("+91"))
                {
                    string msg = "Contact2 should not start with +91";
                    TempData.Put("notify", new StatusResult() { Status = StatusText.Info.ToString(), StatusDetail = msg });
                    ModelState.AddModelError("ContactNo2Mobile", msg);
                    return View(userDetailModelView);
                }
                if (!string.IsNullOrEmpty(userDetailModelView.ContactNo3Mobile) &&
                    userDetailModelView.ContactNo3Mobile.StartsWith("+91"))
                {
                    string msg = "Contact3 should not start with +91";
                    TempData.Put("notify", new StatusResult() { Status = StatusText.Info.ToString(), StatusDetail = msg });
                    ModelState.AddModelError("ContactNo3Mobile", msg);
                    return View(userDetailModelView);
                }

                var userDetail = await MapToUserDetail(photofile, userDetailModelView);

                userDetail.UserInfo = new UserInfo()
                {
                    Id = userDetailModelView.UserInfoId,
                    UserId = userDetailModelView.UserId,
                    UserRole = userDetailModelView.UserRole
                };

                userDetail.IsDetailUpdated = IsRecordUpdated.YES;
                userDetail.ModifiedBy = _session.GetString("UserId");
                userDetail.ModificationDate = DateTime.Now;

                var result = await _userInfoService.UpdateUserDetail(id, userDetail);
                if (result.Status == StatusText.Successful.ToString())
                {
                    _session.SetString("IsDetailU", IsRecordUpdated.YES.ToString());
                    //return to tender dashboard list
                    return RedirectToAction("Index2", "Tenders");
                }
                else if (result.Status == StatusText.Error.ToString())
                {
                    ModelState.AddModelError("", result.StatusDetail);
                }
            }
            return View(userDetailModelView);
        }

        private async Task<UserDetail> MapToUserDetail(IList<IFormFile> photofile, UserDetailModelView userDetailModelView)
        {
            string fullFilePath = string.Empty;

            if (!string.IsNullOrEmpty(userDetailModelView.PhotoUrl))
            {
                if (photofile.Count == 0)
                {
                    fullFilePath = userDetailModelView.PhotoOriginalUrl;
                }
                if (userDetailModelView.PhotoUrl != userDetailModelView.PhotoOriginalUrl)
                {
                    string fileName = userDetailModelView.PhotoUrl;
                    string path = string.Empty;

                    foreach (var file in photofile)
                    {
                        if (file.Length > 0)
                        {
                            path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", _appSettings.Value.PhotoFilePath);
                            if (!Directory.Exists(path))
                            {
                                Directory.CreateDirectory(path);
                            }
                            fullFilePath = Path.Combine(path, fileName);
                            using (var stream = new FileStream(fullFilePath, FileMode.Create))
                            {
                                await file.CopyToAsync(stream);
                            }
                        }
                    }
                }
            }
            var cont1 = string.Empty;
            var cont2 = string.Empty;
            var cont3 = string.Empty;

            if (!string.IsNullOrEmpty(userDetailModelView.ContactNo1))
                cont1 = $"{userDetailModelView.CountryAreaCode}{userDetailModelView.ContactNo1}";

            if (!string.IsNullOrEmpty(userDetailModelView.ContactNo2Mobile))
                cont2 = $"{userDetailModelView.CountryAreaCode}{userDetailModelView.ContactNo2Mobile}";

            if (!string.IsNullOrEmpty(userDetailModelView.ContactNo3Mobile))
                cont3 = $"{userDetailModelView.CountryAreaCode}{userDetailModelView.ContactNo3Mobile}";


            var userDetail = new UserDetail()
            {
                Id = userDetailModelView.Id,
                Salutation = userDetailModelView.Salutation,
                FName = userDetailModelView.FName,
                MName = userDetailModelView.MName,
                LName = userDetailModelView.LName,
                Gender = userDetailModelView.Gender,
                Age = userDetailModelView.Age,
                DOB = userDetailModelView.DOB,
                Address = userDetailModelView.Address,
                City = userDetailModelView.City,
                Pin = userDetailModelView.Pin,
                District = userDetailModelView.District,
                Organisation = userDetailModelView.Organisation,
                Title = userDetailModelView.Title,
                Email1 = userDetailModelView.Email1,
                Email2Optinal = userDetailModelView.Email2Optinal,
                WantEmailNotfi = userDetailModelView.WantEmailNotfi,
                ContactNo1 = cont1,
                ContactNo2Mobile = cont2,
                ContactNo3Mobile = cont3,
                Nationality = userDetailModelView.Nationality,
                WantSMSNotfi = userDetailModelView.WantSMSNotfi,
                WantWhatsUpNotfi = userDetailModelView.WantWhatsUpNotfi,
                PhotoUrl = fullFilePath,
                WebUrl = userDetailModelView.WebUrl,
                PanNo = userDetailModelView.PanNo,
                RegistrationNo = userDetailModelView.RegistrationNo,
                IsDetailUpdated = userDetailModelView.IsDetailUpdated,
                IsActive = userDetailModelView.IsActive,
                CreationDate = userDetailModelView.CreationDate,
                ModificationDate = userDetailModelView.ModificationDate,
                CreatedBy = userDetailModelView.CreatedBy,
                ModifiedBy = userDetailModelView.ModifiedBy

            };
            return userDetail;
        }

        private UserDetailModelView MapToUserDetailModelView(UserDetail userDetail)
        {
            string webphtourl = "";
            if (string.IsNullOrEmpty(userDetail.PhotoUrl))
            {
                webphtourl = Path.Combine("~/", _appSettings.Value.PhotoFilePath, "NoUser.png");
            }
            else
            {
                FileInfo flinfo = new FileInfo(userDetail.PhotoUrl);
                webphtourl = Path.Combine("~/", _appSettings.Value.PhotoFilePath, flinfo.Name);
            }
            var cont1 = string.Empty;
            var cont2 = string.Empty;
            var cont3 = string.Empty;

            if (!string.IsNullOrEmpty(userDetail.ContactNo1))
                cont1 = userDetail.ContactNo1.Length == 10 ? userDetail.ContactNo1 : userDetail.ContactNo1.IndexOf("+91") == 0 ? userDetail.ContactNo1.Replace("+91", "") : userDetail.ContactNo1;
            if (!string.IsNullOrEmpty(userDetail.ContactNo2Mobile))
                cont2 = userDetail.ContactNo2Mobile.Length == 10 ? userDetail.ContactNo2Mobile : userDetail.ContactNo2Mobile.IndexOf("+91") == 0 ? userDetail.ContactNo2Mobile.Replace("+91", "") : userDetail.ContactNo2Mobile;
            if (!string.IsNullOrEmpty(userDetail.ContactNo3Mobile))
                cont3 = userDetail.ContactNo3Mobile.Length == 10 ? userDetail.ContactNo3Mobile : userDetail.ContactNo3Mobile.IndexOf("+91") == 0 ? userDetail.ContactNo3Mobile.Replace("+91", "") : userDetail.ContactNo3Mobile;

            var userDetailMV = new UserDetailModelView()
            {
                Id = userDetail.Id,
                UserInfoId = userDetail.UserInfo.Id,
                UserId = userDetail.UserInfo.UserId,
                UserRole = userDetail.UserInfo.UserRole,
                Salutation = userDetail.Salutation,
                FName = userDetail.FName,
                MName = userDetail.MName,
                LName = userDetail.LName,
                Gender = userDetail.Gender,
                Age = userDetail.Age,
                DOB = userDetail.DOB,
                Address = userDetail.Address,
                City = userDetail.City,
                Pin = userDetail.Pin,
                District = userDetail.District,
                Organisation = userDetail.Organisation,
                Title = userDetail.Title,
                Email1 = userDetail.Email1,
                Email2Optinal = userDetail.Email2Optinal,
                WantEmailNotfi = userDetail.WantEmailNotfi,
                ContactNo1 = cont1,
                ContactNo2Mobile = cont2,
                ContactNo3Mobile = cont3,
                Nationality = userDetail.Nationality,
                WantSMSNotfi = userDetail.WantSMSNotfi,
                WantWhatsUpNotfi = userDetail.WantWhatsUpNotfi,
                PhotoUrl = userDetail.PhotoUrl,
                PhotoOriginalUrl = userDetail.PhotoUrl,
                PhotoRelUrl = webphtourl,
                WebUrl = userDetail.WebUrl,
                PanNo = userDetail.PanNo,
                RegistrationNo = userDetail.RegistrationNo,
                IsDetailUpdated = userDetail.IsDetailUpdated,
                IsActive = userDetail.IsActive,
                CreationDate = userDetail.CreationDate,
                ModificationDate = userDetail.ModificationDate,
                CreatedBy = userDetail.CreatedBy,
                ModifiedBy = userDetail.ModifiedBy

            };
            return userDetailMV;
        }

        public IActionResult Login()
        {
            ViewData["Title"] = $"{_appSettings.Value.AppTitle}-{Subtitle.Login}";
            return View(new LoginViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            ViewData["Title"] = $"{_appSettings.Value.AppTitle}-{Subtitle.Login}";
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Please Enter required data.");
                return View(loginViewModel);
            }
            else
            {
                var userInfo = new UserInfo()
                {
                    UserId = loginViewModel.UserId,
                    Pass = loginViewModel.Pass
                };

                var result = await _userInfoService.ValidateCredentials(userInfo);
                if (result.Status == StatusText.Successful.ToString())
                {
                    var strData = result.Content.ReadAsStringAsync().Result;
                    var userInfoValiResult = JsonConvert.DeserializeObject<UserInfoAuthenticationResult>(strData);
                    if (userInfoValiResult.IsAuthenticated)
                    {
                        var isValid = IsUserValidationTempered(userInfoValiResult);
                        if (isValid)
                        {
                            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                            identity.AddClaim(new Claim("Id", userInfoValiResult.Id.ToString()));
                            identity.AddClaim(new Claim("UserId", userInfoValiResult.UserId));
                            identity.AddClaim(new Claim(ClaimTypes.Role, userInfoValiResult.UserRole.ToString()));

                            //foreach (var role in user.Roles)
                            //{
                            //    identity.AddClaim(new Claim(ClaimTypes.Role, role.Role));
                            //}

                            _session.SetString("Id", userInfoValiResult.Id.ToString());
                            _session.SetString("UserId", userInfoValiResult.UserId);
                            _session.SetString("Role", userInfoValiResult.UserRole.ToString());
                            bool isSubscriptionMade = true;
                            if (userInfoValiResult.UserRole == UserRole.Admin)
                            {
                                identity.AddClaim(new Claim(ClaimTypes.Name, "Admin"));
                                identity.AddClaim(new Claim("IsDetailU", "YES"));
                                _session.SetString("Name", "Admin");
                                _session.SetString("IsDetailU", "YES");
                            }
                            else
                            {
                                var data = await _userInfoService.GetUserInfoDetails(userInfoValiResult.UserId);
                                identity.AddClaim(new Claim(ClaimTypes.Name, data.FullName));
                                identity.AddClaim(new Claim("IsDetailU", data.IsDetailUpdated.ToString()));

                                _session.SetString("Name", data.FullName);
                                _session.SetString("IsDetailU", data.IsDetailUpdated.ToString());

                                if (userInfoValiResult.UserRole == UserRole.Subscriber)
                                {
                                    var dataUSubscriptions = await _userSubscriptionService.GetUserSubscriptionByUserId(data.Id);
                                    _session.SetString("SName", "Service not subscribed yet!");
                                    _session.SetString("VThru", "Invalid date");
                                    if (dataUSubscriptions.Count > 0 )
                                    {
                                        var dataUSubscription = dataUSubscriptions.OrderByDescending(x => x.Id).SingleOrDefault();
                                        if (dataUSubscription.Id != 0)
                                        {
                                            _session.SetString("SName", dataUSubscription.Service.Name);
                                            _session.SetString("VThru", dataUSubscription.ExtendedEndDate.ToString());
                                        }
                                        else
                                        {
                                            isSubscriptionMade = false;
                                        }
                                    }
                                    else
                                    {
                                        isSubscriptionMade = false;
                                    }
                                }
                            }

                            var principal = new ClaimsPrincipal(identity);
                            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                principal, new AuthenticationProperties
                                {
                                    IsPersistent = true,
                                    ExpiresUtc = DateTime.UtcNow.AddMinutes(20)
                                });

                            LoggingInOut(SignInType.In);

                            if (isSubscriptionMade)
                                return RedirectToAction("Index2", "Tenders");
                            else
                                return RedirectToAction("NotSubscribed", "UserInfo");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Credentials and its value has been tempered.");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid userid or password.");
                    }
                }
                else
                {
                    ModelState.AddModelError("", result.StatusDetail);
                }
            }

            ViewData["Title"] = Subtitle.Login;
            return View(loginViewModel);
        }



        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddUserSubscription(int id, string name)
        {
            ViewData["Title"] = $"{_appSettings.Value.AppTitle}-{Subtitle.UserSubscription}";
            var userDetails = await _userInfoService.GetUserDetailById(id);
            var userSubs = new UserSubscriptionViewModel();
            userSubs.UserDetailId = id;
            userSubs.FullName = name;
            userSubs.UserId = userDetails.UserInfo.UserId;
            userSubs.Services = await _serviceService.GetServicesSelectList();

            return View(userSubs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddUserSubscription(UserSubscriptionViewModel userSubModelView)
        {
            try
            {
                ViewData["Title"] = $"{_appSettings.Value.AppTitle}-{Subtitle.UserSubscription}";

                userSubModelView.Services = await _serviceService.GetServicesSelectList();
                var service = await _serviceService.GetServicesById(userSubModelView.ServiceId);

                if (!ModelState.IsValid)
                {
                    string message = "Please enter required data.";
                    TempData.Put("notify", new StatusResult() { Status = StatusText.Error.ToString(), StatusDetail = message });
                    ModelState.AddModelError("", message);
                    return View(userSubModelView);
                }

                if (userSubModelView.UserDetailId == 0 || userSubModelView.ServiceId == 0)
                {
                    string msg = "User need to be selected before proceeding";
                    TempData.Put("notify", new StatusResult() { Status = StatusText.Info.ToString(), StatusDetail = msg });
                    ModelState.AddModelError("UserDetailId", msg);
                    return View(userSubModelView);
                }


                if (userSubModelView.Amount == 0 && service.Duration != DurationType.Weekly)
                {
                    string msg = "Amount should be grater than 0";
                    TempData.Put("notify", new StatusResult() { Status = StatusText.Info.ToString(), StatusDetail = msg });
                    ModelState.AddModelError("ServiceId", msg);
                    return View(userSubModelView);
                }

                var userSub = await MaptoUSerSubscription(userSubModelView);

                var result = await _userSubscriptionService.SaveUserSubscription(userSub);
                if (result.Status == StatusText.Successful.ToString())
                {
                    //_session.SetString("IsDetailU", IsRecordUpdated.YES.ToString());
                    return RedirectToAction("Index", "UserInfo");
                }
                else if (result.Status == StatusText.Error.ToString())
                {
                    ModelState.AddModelError("", result.StatusDetail);
                }

                return View(userSubModelView);
            }
            catch (Exception)
            {
                return View(userSubModelView);
            }
        }

        private async Task<UserSubscription> MaptoUSerSubscription(UserSubscriptionViewModel UsVM)
        {
            var userDetail = await _userInfoService.GetUserDetailById(UsVM.UserDetailId);
            userDetail.UserInfo = null;
            var service = await _serviceService.GetServicesById(UsVM.ServiceId);
            service.ServiceDetails = null;

            return new UserSubscription()
            {
                Id = 0,
                UserDetail = userDetail,
                Service = service,
                StartDate = UsVM.StartDate,
                EndDate = UsVM.EndDate,
                ExtendedEndDate = UsVM.ExtendedEndDate.Value,
                Amount = UsVM.Amount,
                PayingMethod = UsVM.PayingMethod,
                Description = UsVM.Description,
                IsPaid = UsVM.Amount > 0,
                IsActive = IsActive.Y,
                CreatedBy = _session.GetString("UserId"),
                ModifiedBy = _session.GetString("UserId"),
                CreationDate = DateTime.Now,
                ModificationDate = DateTime.Now
            };
        }

        private async void LoggingInOut(SignInType signInType)
        {
            try
            {
                var usLog = new UserSignInLog()
                {
                    Id = 0,
                    UserInfo = new UserInfo
                    {
                        Id = int.Parse(_session.GetString("Id")),
                        UserId = _session.GetString("UserId")
                        //UserRole = _session.GetString("UserRole")
                    },
                    SignInTime = DateTime.Now,
                    SignInType = signInType
                };
                var resultSI = await _userInfoService.SaveSigninLog(usLog);
                if (resultSI.Status == StatusText.Successful.ToString())
                {
                    Log.Logger.Information(resultSI.StatusDetail);
                }
                else
                {
                    Log.Logger.Error(resultSI.StatusDetail);
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
            }
        }

        [Authorize(Roles = "Admin, Operator, Subscriber")]
        public IActionResult Logout()
        {
            ViewData["Title"] = $"{_appSettings.Value.AppTitle}-{Subtitle.TenderMain}";
            LoggingInOut(SignInType.Out);
            HttpContext.SignOutAsync();
            _session.Clear();
            return RedirectToAction("Index", "Tenders");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        [Authorize(Roles = "Subscriber")]
        public IActionResult NotSubscribed()
        {
            return View();
        }

        public async Task<JsonResult> GetUserExistingSubscriptions(int userdetailid)
        {
            try
            {
                var subscriptions = await _userSubscriptionService.GetUserSubscriptionByUserId(userdetailid);
                var orderedSubs = subscriptions.OrderByDescending(x => x.Id);
                return Json(new { datas = orderedSubs, tcount = orderedSubs.Count(), rcount = orderedSubs.Count(), status = "Successful", error = "" });
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return Json(new { datas = new UserSubscription(), tcount = 0, rcount = 0, status = "Successful", error = "" });
            }
        }

        private bool IsUserValidationTempered(UserInfoAuthenticationResult userInfoAuthenticationResult)
        {
            string strdata = $"{userInfoAuthenticationResult.UserId}~{userInfoAuthenticationResult.IsAuthenticated.ToString()}~{userInfoAuthenticationResult.UserRole.ToString()}";
            return _encryptDecrypt.VerifyHashedPassword(userInfoAuthenticationResult.HashedData, strdata);
        }

    }
}