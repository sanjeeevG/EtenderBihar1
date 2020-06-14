using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETB.Core.Entities;
using ETB.WebApp.Models;
using ETB.WebApp.Services;
using ETB.WebApp.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ETB.WebApp.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IOptions<ApplicationSettings> _appSettings;
        private readonly ISession _session;
        private readonly IHostingEnvironment _environment;
        private readonly IOptions<BankDetails> _bankDetails;
        private readonly ServiceService _serviceservice;

        public ServicesController(IOptions<ApplicationSettings> appSettings,
             IHttpContextAccessor httpContextAccessor,
             IHostingEnvironment environment,
             IOptions<BankDetails> bankDetails,
             ServiceService serviceservice
            )
        {
            _appSettings = appSettings;
            _session = httpContextAccessor.HttpContext.Session;
            _environment = environment;
            _bankDetails = bankDetails;
            _serviceservice = serviceservice;
        }

        public async Task<IActionResult> ServiceView()
        {
            ViewData["Title"] = $"{_appSettings.Value.AppTitle}-{Subtitle.ServiceList}";
            var services = await _serviceservice.GetServices();
            return View(services);
        }

        public  IActionResult Index()
        {
            return View();
        }

        public IActionResult OtherServices()
        {
            ViewData["Title"] = $"{_appSettings.Value.AppTitle}-{Subtitle.OtherServices}";
            return View();
        }


        public async Task<JsonResult> GetServices()
        {
            try
            {
                var services = await _serviceservice.GetServices();
                //var serViewModel = MaptoServiceViewModel(services);

                return Json(new { datas = services, tcount = services.Count(), rcount = 0, status = "Successful", message = "" });
            }
            catch (Exception ex)
            {
                return Json(new { datas = new List<Service>(), tcount = 0, rcount = 0, status = "Error", message = ex.Message });
            }
            
        }

        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> GetSpService(int id)
        {
            try
            {
                var service = await _serviceservice.GetServicesById(id);
                var dur = (int)DurationType.Weekly;
                var startDate = DateTime.Now;
                var endDate = startDate.AddDays(dur);
                var value = service.Price;
                if (service.Duration == DurationType.Annually)
                {
                    dur = (int)DurationType.Annually;
                    endDate = startDate.AddDays(dur);
                }
                else if(service.Duration == DurationType.HalfAnnually)
                {
                    dur = (int)DurationType.HalfAnnually;
                    endDate = startDate.AddDays(dur);
                }
                else if (service.Duration == DurationType.Quaterly)
                {
                    dur = (int)DurationType.Quaterly;
                    endDate = startDate.AddDays(dur);
                }
                else if (service.Duration == DurationType.Monthly)
                {
                    dur = (int)DurationType.Monthly;
                    endDate = startDate.AddDays(dur);
                }

                return Json(new { datas = new {Duration=dur, stDate=startDate, enDate=endDate, val=value }, tcount = 1, rcount = 1, status = "Successful", message = "" });
            }
            catch (Exception ex)
            {
                return Json(new { datas = new { }, tcount = 0, rcount = 0, status = "Error", message = ex.Message });
            }

        }

        //[Authorize(Roles = "Admin")]
        //public async Task<IActionResult> ChangeUserService(int id)
        //{
        //ViewData["Title"] = $"{_appSettings.Value.AppTitle}-{Subtitle.UserServiceChange}";
        ////var result = await _userInfoService.GetUserDetailById(id);
        //var changePassVM = new ChangeUsersPassViewModel();

        //if (result != null)
        //{
        //    changePassVM = new ChangeUsersPassViewModel()
        //    {
        //        UserId = result.UserInfo.UserId,
        //        UserIdEncr = _dataProtector.Encrypt(result.UserInfo.UserId),
        //        FullName = result.FullName,
        //        Pass = ""
        //    };
        //}
        //else
        //{
        //    ViewBag.Message = new StatusResult() { Status = StatusText.Error.ToString(), StatusDetail = "This user is either not active or does not exists" };
        //}
        //return View("ServiceView", changePassVM);
        //}

        private ServiceViewModel MaptoServiceViewModel(Service service)
        {
            return new ServiceViewModel()
            {
                Id = service.Id,
                Name = service.Name, 
                Description = service.Description, 
                ServiceRepUrl = service.ServiceRepUrl, 
                Duration = service.Duration, 
                Price = service.Price, 
                ServiceType = service.ServiceType, 
                IsActive = service.IsActive, 
                CreatedBy = service.CreatedBy, 
                CreationDate = service.CreationDate, 
                ModificationDate = service.ModificationDate, 
                ModifiedBy = service.ModifiedBy, 
                ServiceDetails = service.ServiceDetails
            };
        }

    }
}