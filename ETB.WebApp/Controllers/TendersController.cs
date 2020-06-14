using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ETB.Core.Entities;
using ETB.Utilities;
using ETB.WebApp.Models;
using ETB.WebApp.Services;
using ETB.WebApp.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Serilog;

namespace ETB.WebApp.Controllers
{
    public class TendersController : Controller
    {
        private readonly IOptions<ApplicationSettings> _appSettings;
        private readonly ISession _session;
        private readonly IHostingEnvironment _environment;
        private readonly TenderService _tenderService;
        private readonly StateService _stateSerice;
        private readonly DistrictService _districtSerice;
        private readonly DivisionService _divisionService;

        public TendersController(IOptions<ApplicationSettings> appSettings,
             IHttpContextAccessor httpContextAccessor,
             IHostingEnvironment environment,
            TenderService tenderService,
            StateService stateSerice,
            DistrictService districtSerice,
            DivisionService divisionService)
        {
            _appSettings = appSettings;
            _session = httpContextAccessor.HttpContext.Session;
            _environment = environment;
            _tenderService = tenderService;
            _stateSerice = stateSerice;
            _districtSerice = districtSerice;
            _divisionService = divisionService;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = $"{_appSettings.Value.AppTitle}-{Subtitle.TenderMain}";
            return View();
        }

        [Authorize(Roles = "Admin, Operator, Subscriber")]
        public async Task<IActionResult> Index2()
        {
            ViewData["Title"] = $"{_appSettings.Value.AppTitle}-{Subtitle.TenderDashBoard}";
            //if (!_session.IsAvailable || _session.GetString("UserId") == null)
            //{
            //    return RedirectToAction("Login", "UserInfo");
            //}
            //else
            //{
            var tenders = await _tenderService.GetTenderData("0");
            var filteredData = tenders;
            
            //filteredData = filteredData.Where(x => x.BidSubmissionEnDate >= DateTime.Now).ToList();

            //if (filteredData.Count == 0)
            //{
            //    filteredData = tenders;
            //}

            var nits = filteredData.Select(x => x.NIT)
                        .Distinct()
                        .Select(x => new SelectListItem()
                        {
                            Text = x,
                            Value = x
                        });

            var orgs = filteredData.Select(x => x.Organisation)
                        .Distinct()
                        .Select(x => new SelectListItem()
                        {
                            Text = x,
                            Value = x
                        });

            var depts = filteredData.Select(x => x.Department)
                        .Distinct()
                        .Select(x => new SelectListItem()
                        {
                            Text = x,
                            Value = x
                        });

            List<string> divs = new List<string>();
            foreach (var div in filteredData.Select(x => x.Division)
                        .ToList())
            {
                if (!string.IsNullOrEmpty(div))
                    divs.AddRange(div.Split(","));
            }

            var noOfRowlst = _appSettings.Value.NoOfRowsOptions.Split(',').ToList();
            var rowOption = _appSettings.Value.DefaultOptionRowSel;
            List<SelectListItem> NoOfRowsSelItemLst = new List<SelectListItem>();
            foreach (var x in noOfRowlst)
            {
                NoOfRowsSelItemLst.Add(new SelectListItem() { Value = x, Text = x, Selected = (x == rowOption) });
            }


            var i2viewmodel = new Index2ViewModel()
            {
                Nits = nits.ToList(),
                Departments = depts.ToList(),
                Oganisations = orgs.ToList(),
                Divisions = divs.Distinct().Select(x => new SelectListItem()
                {
                    Text = x,
                    Value = x
                }).ToList(),
                NoOfRows = NoOfRowsSelItemLst
            };


            return View(i2viewmodel);
            //}

        }

        [Authorize(Roles = "Admin, Operator, Subscriber")]
        public async Task<IActionResult> View(int id)
        {
            ViewData["Title"] = $"{_appSettings.Value.AppTitle}-{Subtitle.TenderView}";
            var tender = await _tenderService.GetTenderById(id);
            var tenderViewModel = MapToTenderViewMododel(tender);

            return View(tenderViewModel);
        }

        [Authorize(Roles = "Admin,Operator")]
        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Title"] = $"{_appSettings.Value.AppTitle}-{Subtitle.TenderEdit}";
            var tender = await _tenderService.GetTenderById(id);
            var tenderViewModel = MapToTenderViewMododel(tender);
            tenderViewModel = await FillTenderListItems(tenderViewModel);

            return View(tenderViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Operator")]
        public async Task<IActionResult> Edit(int id, IList<IFormFile> formFile, TenderViewModel tenderViewModel)
        {

            tenderViewModel = await FillTenderListItems(tenderViewModel);

            if (!ModelState.IsValid)
            {
                string message = "Please enter required data.";
                TempData.Put("notify", new StatusResult() { Status = StatusText.Error.ToString(), StatusDetail = message });
                ModelState.AddModelError("", message);
                return View(tenderViewModel);
            }
            else
            {
                var tender = await MaptoTender(formFile, tenderViewModel);

                tender.ModificationDate = DateTime.Now;
                tender.ModifiedBy = _session.GetString("UserId");

                var result = await _tenderService.UpdateTender(id, tender);
                TempData.Put("notify", result);
                if (result.Status == StatusText.Successful.ToString())
                {
                    // return to List Mode
                    //if (result.Data.Length > 0)
                    //{
                    //    var resultObj = JsonConvert.DeserializeObject<Tender>(result.Data);
                    return RedirectToAction("Index2", "Tenders");
                    //    return RedirectToAction("Index2", "Tenders");
                    //}
                }
                else if (result.Status == StatusText.Error.ToString())
                {
                    ModelState.AddModelError("", result.StatusDetail);
                }
            }

            return View(tenderViewModel);
        }

        public async Task<IActionResult> Corr(int id)
        {
            var tender = await _tenderService.GetTenderById(id);
            // change the tender 
            tender.Id = 0;
            tender.ParentTenderId = id;
            tender.CreationDate = DateTime.Now;
            tender.ModificationDate = DateTime.Now;
            tender.CreatedBy = _session.GetString("UserId");
            tender.ModifiedBy = _session.GetString("UserId");

            if (tender.TenderDocs != null &&
                tender.TenderDocs.Count() == 1)
            {
                if (tender.TenderDocs[0].DocFor == DocFor.NIT)
                {
                    tender.TenderDocs[0].Id = 0;
                }
            }


            // Save the tender:
            var result = await _tenderService.SaveNewTender(tender);
            TempData.Put("notify", result);
            int returnedId = 0;
            if (result.Status == StatusText.Successful.ToString())
            {
                if (result.Data.Length > 0)
                {
                    var resultObj = JsonConvert.DeserializeObject<Tender>(result.Data);
                    returnedId = resultObj.Id;
                }
            }
            else if (result.Status == StatusText.Error.ToString())
            {
                ModelState.AddModelError("", result.StatusDetail);
            }

            return RedirectToAction("Edit", "Tenders", new { id = returnedId });

        }

        private TenderViewModel MapToTenderViewMododel(Tender tender)
        {
            if (tender == null)
            {
                return new TenderViewModel();
            }
            var tenderDocs = new List<TenderDocViewModel>();
            if (tender.TenderDocs != null)
            {
                foreach (var td in tender.TenderDocs)
                {
                    tenderDocs.Add(new TenderDocViewModel()
                    {
                        Id = td.Id,
                        DocName = td.DocName,
                        DocPath = td.DocPath,
                        DocFor = td.DocFor,
                        DocRelPathName = Path.Combine("~/", _appSettings.Value.NitFilePath, td.DocName),
                        TenderCreatedDate = tender.ePublishDate
                    });
                }
            }
            return new TenderViewModel()
            {
                Id = tender.Id,
                NIT = tender.NIT,
                TenderRef = tender.TenderRef,
                WorkNo = tender.WorkNo,
                TenderType = tender.TenderType,
                TenderTitle = tender.TenderTitle,
                DescOfWork = tender.DescOfWork,
                Department = tender.Department,
                Organisation = tender.Organisation,
                TenderDocument = "",
                TenderDocumentPath = "",
                TenderRelDocumentFilePath = "",
                TenderDocs = tenderDocs,
                TenderRefSiteAddress = tender.TenderRefSiteAddress,
                BidOpeningDate = tender.BidOpeningDate,
                BidSubmissionStDate = tender.BidSubmissionStDate,
                BidSubmissionEnDate = tender.BidSubmissionEnDate,
                CostOfBOQ = tender.CostOfBOQ,
                COT = tender.COT,
                EMD = tender.EMD,
                Region = tender.Region,
                EstimatedCost = tender.EstimatedCost,
                Currency = tender.Currency,
                District = tender.District,
                Division = tender.Division,
                SelDivisions = !string.IsNullOrEmpty(tender.Division) ? tender.Division.Split(",").ToList() : new List<string>(),
                DocumentDownloadStDate = tender.DocumentDownloadStDate,
                DocumentDownloadEdDate = tender.DocumentDownloadEdDate,
                ePublishDate = tender.ePublishDate,
                IsActive = tender.IsActive,
                PublishOrLive = tender.PublishOrLive,
                ParentTenderId = tender.ParentTenderId,
                PaymentOption = tender.PaymentOption,
                PayableAt = tender.PayableAt,
                EMDPaymentOption = tender.EMDPaymentOption,
                EMDPaymentOptions = string.IsNullOrEmpty(tender.EMDPaymentOption) ? new List<string>() : tender.EMDPaymentOption.Split(',').ToList<string>(),
                EMDPayableAt = tender.EMDPayableAt,
                UnEmployedEng = tender.UnEmployedEng,
                BankCertificate = tender.BankCertificate,
                CreatedBy = tender.CreatedBy,
                ModifiedBy = tender.ModifiedBy,
                CreationDate = tender.CreationDate,
                ModificationDate = tender.ModificationDate,
                ValueFactor = tender.ValueFactor
            };
        }

        private async Task<Tender> MaptoTender(IList<IFormFile> formFile, TenderViewModel tenderViewModel)
        {
            if (tenderViewModel == null)
            {
                return new Tender();
            }

            var tenderDocs = new List<TenderDoc>();
            if (tenderViewModel.TenderDocs != null)
            {
                foreach (var tvmd in tenderViewModel.TenderDocs)
                {
                    tenderDocs.Add(new TenderDoc()
                    {
                        Id = tvmd.Id,
                        DocName = tvmd.DocName,
                        DocPath = tvmd.DocPath,
                        DocFor = tvmd.DocFor
                    });
                }
            }


            if (!string.IsNullOrEmpty(tenderViewModel.TenderDocument))
            {
                string fileName = tenderViewModel.TenderDocument;
                string nitFilePath = string.Empty;
                string path = string.Empty;
                foreach (var file in formFile)
                {
                    if (file.Length > 0)
                    {
                        path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", _appSettings.Value.NitFilePath);
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        nitFilePath = Path.Combine(path, fileName);
                        using (var stream = new FileStream(nitFilePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                    }
                }

                tenderDocs.Add(new TenderDoc()
                {
                    DocName = fileName,
                    DocPath = path,
                    DocFor = tenderViewModel.ParentTenderId == 0 ? DocFor.NIT : DocFor.Corrigendum
                });

            }


            return new Tender()
            {
                Id = tenderViewModel.Id,
                PublishOrLive = tenderViewModel.PublishOrLive,
                NIT = tenderViewModel.NIT,
                TenderRef = tenderViewModel.TenderRef,
                WorkNo = tenderViewModel.WorkNo,
                TenderType = tenderViewModel.TenderType,
                TenderTitle = tenderViewModel.TenderTitle,
                DescOfWork = tenderViewModel.DescOfWork,
                Department = tenderViewModel.Department,
                Organisation = tenderViewModel.Organisation,
                //TenderDocument = tenderViewModel.TenderDocument,
                TenderDocs = tenderDocs,
                TenderRefSiteAddress = tenderViewModel.TenderRefSiteAddress,
                BidOpeningDate = tenderViewModel.BidOpeningDate.Value,
                BidSubmissionStDate = tenderViewModel.BidSubmissionStDate,
                BidSubmissionEnDate = tenderViewModel.BidSubmissionEnDate.Value,
                CostOfBOQ = tenderViewModel.CostOfBOQ,

                COT = tenderViewModel.COT,
                EMD = tenderViewModel.EMD,
                //EMDPaymentOptions = tenderViewModel.EMDPaymentOptions,
                EMDPaymentOption = tenderViewModel.EMDPaymentOption,
                EMDPayableAt = tenderViewModel.EMDPayableAt,
                Region = tenderViewModel.Region,
                EstimatedCost = tenderViewModel.EstimatedCost,
                Currency = tenderViewModel.Currency,
                District = tenderViewModel.District,
                Division = tenderViewModel.SelDivisions != null ? string.Join(",", tenderViewModel.SelDivisions) : "",
                DocumentDownloadStDate = tenderViewModel.DocumentDownloadStDate,
                DocumentDownloadEdDate = tenderViewModel.DocumentDownloadEdDate,
                ePublishDate = tenderViewModel.ePublishDate,
                UnEmployedEng = tenderViewModel.UnEmployedEng,
                BankCertificate = tenderViewModel.BankCertificate,
                IsActive = tenderViewModel.IsActive,
                ParentTenderId = tenderViewModel.ParentTenderId,
                PaymentOption = tenderViewModel.PaymentOption,
                PayableAt = tenderViewModel.PayableAt,
                CreatedBy = tenderViewModel.CreatedBy,
                ModifiedBy = tenderViewModel.ModifiedBy,
                CreationDate = tenderViewModel.CreationDate,
                ModificationDate = tenderViewModel.ModificationDate,
                ValueFactor = tenderViewModel.ValueFactor
            };
        }

        private async Task<TenderViewModel> FillTenderListItems(TenderViewModel tenderViewModel)
        {
            tenderViewModel.States = await _stateSerice.GetStateSelectList();
            tenderViewModel.DefaultSelSTate = _appSettings.Value.DefaultSelState;
            tenderViewModel.Districts = await _districtSerice.GetDistrictSelectList();
            tenderViewModel.Divisions = await _divisionService.GetDivisionSelectList(string.Empty);
            tenderViewModel.TenderTypes = _tenderService.GetTenderTypes();
            return tenderViewModel;
        }

        [Authorize(Roles = "Admin,Operator")]
        public async Task<IActionResult> Create(int? refid)
        {
            ViewData["Title"] = $"{_appSettings.Value.AppTitle}-{Subtitle.TenderCreate}";
            var ternderViewModel = new TenderViewModel();
            ternderViewModel.RefId = 0;

            if (refid != null)
            {
                var tender = await _tenderService.GetTenderById(refid.Value);
                ternderViewModel = MapToTenderViewMododel(tender);
                ternderViewModel.RefId = refid.Value;
                ternderViewModel.Id = 0;
                ternderViewModel.TenderTitle = string.Empty;
                ternderViewModel.DescOfWork = string.Empty;
                ternderViewModel.EstimatedCost = 0;
                ternderViewModel.CostOfBOQ = 0;
                ternderViewModel.EMD = 0;
            }
            ternderViewModel = await FillTenderListItems(ternderViewModel);
            ternderViewModel.TenderType = "Open";
            ternderViewModel.Currency = Currency.INR;
            ternderViewModel.ValueFactor = _appSettings.Value.DefaultValueIn;


            return View(ternderViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Operator")]
        public async Task<IActionResult> Create(IList<IFormFile> formFile, TenderViewModel tenderViewModel)
        {

            tenderViewModel = await FillTenderListItems(tenderViewModel);

            if (!ModelState.IsValid)
            {
                string message = "Please enter required data.";
                TempData.Put("notify", new StatusResult() { Status = StatusText.Error.ToString(), StatusDetail = message });
                ModelState.AddModelError("", message);
                return View(tenderViewModel);
            }
            else
            {
                var tender = await MaptoTender(formFile, tenderViewModel);

                // Get older tender for refid
                // if that tender has documents associate it. 
                if (tenderViewModel.RefId != 0)
                {
                    var tenderRef = await _tenderService.GetTenderById(tenderViewModel.RefId);
                    if (tenderRef.TenderDocs != null)
                    {
                        var tenderdocs = new List<TenderDoc>();
                        foreach (var tdRef in tenderRef.TenderDocs)
                        {
                            tenderdocs.Add(new TenderDoc()
                            {
                                Id = 0,
                                DocName = tdRef.DocName,
                                DocPath = tdRef.DocPath,
                                DocFor = tdRef.DocFor
                            });
                        }

                        tender.TenderDocs = tenderdocs;
                    }
                }

                tender.IsActive = IsActive.Y;
                tender.CreationDate = DateTime.Now;
                tender.ModificationDate = DateTime.Now;
                tender.CreatedBy = _session.GetString("UserId");
                tender.ModifiedBy = _session.GetString("UserId");

                var result = await _tenderService.SaveNewTender(tender);
                TempData.Put("notify", result);
                if (result.Status == StatusText.Successful.ToString())
                {
                    // return to List Mode
                    if (result.Data.Length > 0)
                    {
                        var resultObj = JsonConvert.DeserializeObject<Tender>(result.Data);
                        //return RedirectToAction("Edit", "Tenders", new { id = resultObj.Id});
                        return RedirectToAction("Index2", "Tenders");
                    }
                }
                else if (result.Status == StatusText.Error.ToString())
                {
                    ModelState.AddModelError("", result.StatusDetail);
                }
            }
            return View(tenderViewModel);
        }

        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> DeleteTender(int id)
        {
            try
            {
                var result = await _tenderService.DeleteTender(id);

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

        public async Task<JsonResult> GetDivisionsForDistOrDept(DivisionFilterViewModel divisionFilterViewModel)
        {
            var divisions = await _divisionService.GetDivisions();
            IList<Division> filteredDivs = divisions;
            try
            {
                if (divisions != null || divisions.Count > 0)
                {
                    if (!string.IsNullOrEmpty(divisionFilterViewModel.District))
                        filteredDivs = filteredDivs.Where(x => x.DistrictName == divisionFilterViewModel.District).ToList();

                    if (!string.IsNullOrEmpty(divisionFilterViewModel.Department))
                        filteredDivs = filteredDivs.Where(x => x.Deptartment == divisionFilterViewModel.Department).ToList();

                }
                return Json(new { datas = filteredDivs, tcount = divisions.Count(), rcount = filteredDivs.Count(), status = "Successful", error = "" });
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return Json(new { datas = new List<Division>(), tcount = 0, rcount = 0, status = "Error", error = ex.Message });
            }
        }

        public async Task<JsonResult> GetStatistics(DivisionFilterViewModel divisionFilterViewModel)
        {
            try
            {
                var tenders = await _tenderService.GetTenderData("0");
                var filteredData = tenders;
                filteredData = filteredData.Where(x => x.BidSubmissionEnDate >= DateTime.Now).ToList();

                var totalATenders = filteredData.Count();
                var totalAValueupto = filteredData.Count(x => x.EstimatedCost <= 25);
                var totalAValuemorethan = filteredData.Count(x => x.EstimatedCost > 25);
                var totalExpinSevDays = filteredData.Count(x => (x.BidSubmissionEnDate - DateTime.Now).TotalDays <= 7);

                return Json(new { datas = new { AT = totalATenders, ATValUpto = totalAValueupto, ATValMoreThan = totalAValuemorethan, ATExpSevDays = totalExpinSevDays }, tcount = 0, rcount = 0, status = "Successful", error = "" });
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return Json(new { datas = new { AT = 0, ATValUpto = 0, ATValMoreThan = 0, ATExpSevDays = 0 }, tcount = 0, rcount = 0, status = "Successful", error = "" });
            }
        }

        [Authorize(Roles = "Admin, Operator, Subscriber")]
        public async Task<JsonResult> GetTenderData(FilterModel filterCond)
        {
            try
            {
                var data = await _tenderService.GetTenderData("0");

                IList<Tender> filteredData = data;

                if (!string.IsNullOrEmpty(filterCond.Archive))
                {
                    if (filterCond.Archive == "Y")
                    {
                        filteredData = filteredData.Where(x => x.BidSubmissionEnDate < DateTime.Now).ToList();
                    }
                    else
                    {
                        filteredData = filteredData.Where(x => x.BidSubmissionEnDate >= DateTime.Now).ToList();
                    }
                }

                if (!string.IsNullOrEmpty(filterCond.ExpInSevenDays))
                {
                    if (filterCond.ExpInSevenDays == "Y")
                    {
                        filteredData = filteredData.Where(x => (x.BidSubmissionEnDate - DateTime.Now).TotalDays <= 7).ToList();
                    }
                }


                if (!string.IsNullOrEmpty(filterCond.PublishOrLive))
                    filteredData = filteredData.Where(x => ((int)x.PublishOrLive).ToString() == filterCond.PublishOrLive).ToList();
                if (!string.IsNullOrEmpty(filterCond.District))
                    filteredData = filteredData.Where(x => x.District == filterCond.District).ToList();
                if (!string.IsNullOrEmpty(filterCond.NIT))
                    filteredData = filteredData.Where(x => x.NIT == filterCond.NIT).ToList();
                if (!string.IsNullOrEmpty(filterCond.Organisation))
                    filteredData = filteredData.Where(x => x.Organisation == filterCond.Organisation).ToList();
                if (!string.IsNullOrEmpty(filterCond.Department))
                    filteredData = filteredData.Where(x => x.Department == filterCond.Department).ToList();
                if (!string.IsNullOrEmpty(filterCond.Division))
                    filteredData = filteredData.Where(x => x.Division != null && x.Division.Contains(filterCond.Division)).ToList();
                if (!string.IsNullOrEmpty(filterCond.TendCor))
                {
                    if (filterCond.TendCor == "T")
                        filteredData = filteredData.Where(x => x.ParentTenderId == 0).ToList();
                    else if (filterCond.TendCor == "C")
                        filteredData = filteredData.Where(x => x.ParentTenderId != 0).ToList();
                }
                var orderedData = filteredData.OrderByDescending(x => x.Id);

                var countSevenDays = filteredData.Where(x => (x.BidSubmissionEnDate - DateTime.Now).TotalDays <= 7).ToList();

                return Json(new { datas = orderedData, tcount = data.Count(), rcount = orderedData.Count(), rcountsendays = countSevenDays.Count(), status = "Successful", error = "" });
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return Json(new { datas = new List<Tender>(), tcount = 0, rcount = 0, rcountsendays = 0, status = "Error", error = ex.Message });
            }
        }

        public async Task<JsonResult> GetTenderPartialData()
        {
            try
            {
                var data = await _tenderService.GetTenderPartialData().ConfigureAwait(false);
                var filteredData = data;
                //filteredData = filteredData.Where(x => x.BidSubmissionEnDate >= DateTime.Now).ToList();
                var orderedData = filteredData.OrderByDescending(x => x.Id);
                return Json(new { datas = orderedData, tcount = data.Count(), rcount = orderedData.Count(), status = "Successful", error = "" });
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return Json(new { datas = new List<Tender>(), tcount = 0, rcount = 0, status = "Error", error = ex.Message });
            }
        }

        public async Task<JsonResult> GetDistrictWiseCount()
        {
            try
            {
                var data = await _tenderService.GetDistrictWiseCount().ConfigureAwait(false);
                return Json(new { datas = data, status = "Successful", error = "" });
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return Json(new { datas = new List<DistrictTenderCountViewModel>(), status = "Error", error = ex.Message });

            }
        }
    }
}