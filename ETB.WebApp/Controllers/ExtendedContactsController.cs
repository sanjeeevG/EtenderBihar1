using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETB.Core.Entities;
using ETB.Utilities;
using ETB.WebApp.Models;
using ETB.WebApp.Services;
using ETB.WebApp.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;

namespace ETB.WebApp.Controllers
{
    public class ExtendedContactsController : Controller
    {
        private readonly ExtendedContactService _extendedContactService;

        private readonly IOptions<ApplicationSettings> _appSettings;
        private readonly DataProtector _dataProtector;
        private readonly EncryptionDecryption _encryptDecrypt;
        private readonly ISession _session;
        private readonly HttpRequest _request;
        private readonly DistrictService _districtSerice;
        private readonly EmailSenderService _emailSenderService;
        private readonly SMSSenderService _smsSenderService;


        public ExtendedContactsController(IOptions<ApplicationSettings> appSettings,
            DataProtector dataProtector,
            EncryptionDecryption encryptDecrypt,
            IHttpContextAccessor httpContextAccessor,
            ExtendedContactService extendedContactService,
            DistrictService districtSerice,
            EmailSenderService emailSenderService,
            SMSSenderService smsSenderService)
        {
            _appSettings = appSettings;
            _dataProtector = dataProtector;
            _encryptDecrypt = encryptDecrypt;
            //_protector = protectionProvider.CreateProtector(GetType().FullName);
            _session = httpContextAccessor.HttpContext.Session;
            _request = httpContextAccessor.HttpContext.Request;
            _extendedContactService = extendedContactService;
            _districtSerice = districtSerice;
            _emailSenderService = emailSenderService;
            _smsSenderService = smsSenderService;
        }

        //[Authorize("Admin")]
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = $"{_appSettings.Value.AppTitle}-{Subtitle.OtherToolsExContactIndex}";
            var noOfRowlst = _appSettings.Value.NoOfRowsOptions.Split(',').ToList();
            var rowOption = _appSettings.Value.DefaultOptionRowSel;
            List<SelectListItem> NoOfRowsSelItemLst = new List<SelectListItem>();
            foreach (var x in noOfRowlst)
            {
                NoOfRowsSelItemLst.Add(new SelectListItem() { Value = x, Text = x, Selected = (x == rowOption) });
            }

            var indexVM = new ExContactIndexViewModel()
            {
                Districts = await _districtSerice.GetDistrictSelectList(),
                NoOfRows = NoOfRowsSelItemLst
            };
            return View(indexVM);
        }

        public async Task<JsonResult> GetExContacts(ExContactIndexViewModel filterCond)
        {
            try
            {
                var contacts = await _extendedContactService.GetExternalContacts();
                IList<ExternalContact> filteredData = contacts;

                if (!string.IsNullOrEmpty(filterCond.FullName))
                    filteredData = filteredData.Where(x => x.FullName.ToLower().Contains(filterCond.FullName.Trim().ToLower())).ToList();

                if (!string.IsNullOrEmpty(filterCond.ContactNo1))
                    filteredData = filteredData.Where(x => x.ContactNo1.ToLower().EndsWith(filterCond.ContactNo1.Trim())).ToList();

                if (!string.IsNullOrEmpty(filterCond.City))
                    filteredData = filteredData.Where(x => x.City.EmptyIfNull().ToLower().Contains(filterCond.City.Trim().ToLower())).ToList();

                if (!string.IsNullOrEmpty(filterCond.District))
                    filteredData = filteredData.Where(x => x.District.EmptyIfNull() == filterCond.District).ToList();

                if (!string.IsNullOrEmpty(filterCond.Class))
                    filteredData = filteredData.Where(x => x.Class.EmptyIfNull().ToLower() == filterCond.Class.Trim().ToLower()).ToList();

                var orderedData = filteredData.OrderByDescending(x => x.Id);

                string strNums = String.Empty;
                string strEmails  = String.Empty;
                if (filteredData.Count() > 0 )
                {
                    var nums = filteredData.ToList().Select(x => x.ContactNo1).Distinct();
                    var emails = filteredData.ToList().Select(x => x.Email1).Distinct();
                    strNums = string.Join(",", nums);
                    strEmails = string.Join(",", emails);
                }

                return Json(new { datas = orderedData, Emails = strEmails, Nums = strNums,  tcount = contacts.Count(), rcount = filteredData.Count(), status = "Successful", message = "" });
            }
            catch (Exception ex)
            {
                var contacts = new List<ExternalContact>();
                return Json(new { datas = contacts, Emails = string.Empty , Nums = string.Empty , tcount = contacts.Count(), rcount = contacts.Count(), status = "Successful", message = ex.Message });
            }
        }
    }
}