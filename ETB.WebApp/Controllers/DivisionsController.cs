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
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Serilog;

namespace ETB.WebApp.Controllers
{
    public class DivisionsController : Controller
    {

        private readonly IOptions<ApplicationSettings> _appSettings;
        private readonly ISession _session;
        private readonly IHostingEnvironment _environment;
        private readonly DivisionService _divisionService;
        private readonly DistrictService _districtSerice;

        public DivisionsController(IOptions<ApplicationSettings> appSettings,
             IHttpContextAccessor httpContextAccessor,
             IHostingEnvironment environment,
             DistrictService districtSerice,
            DivisionService divisionService)
        {
            _appSettings = appSettings;
            _session = httpContextAccessor.HttpContext.Session;
            _environment = environment;
            _districtSerice = districtSerice;
            _divisionService = divisionService;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = $"{_appSettings.Value.AppTitle}-{Subtitle.DivisionList}";
            var noOfRowlst = _appSettings.Value.NoOfRowsOptions.Split(',').ToList();
            var rowOption = _appSettings.Value.DefaultOptionRowSel;
            List<SelectListItem> NoOfRowsSelItemLst = new List<SelectListItem>();
            foreach (var x in noOfRowlst)
            {
                NoOfRowsSelItemLst.Add(new SelectListItem() { Value = x, Text = x, Selected = (x == rowOption) });
            }

            var dataviewmodel = new DivisionViewModel()
            {
                Id = 0,
                Districts = await _districtSerice.GetDistrictSelectList(),
                DV_District = "",
                DV_Division = "",
                DV_Department = "",
                NoOfRows = NoOfRowsSelItemLst
            };
            return View(dataviewmodel);
        }

        public async Task<JsonResult> CreateNewDivision(DivisionViewModel divisionViewModel)
        {
            try
            {
                Division division = new Division()
                {
                    Id = 0,
                    Deptartment = divisionViewModel.DV_Department,
                    DistrictName = divisionViewModel.DV_District,
                    DivisionName = divisionViewModel.DV_Division,
                    CreatedBy = _session.GetString("UserId"),
                    CreationDate = DateTime.Now
                };

                var result = await _divisionService.SaveNewDivision(division);
                TempData.Put("notify", result);
                Division resultObj = new Division();
                if (result.Status == StatusText.Successful.ToString())
                {
                    if (result.Data.Length > 0)
                    {
                        resultObj = JsonConvert.DeserializeObject<Division>(result.Data);
                    }
                    return Json(new { datas = resultObj.Id, status = "Successful", error = "" });
                }
                else
                {
                    return Json(new { datas = 0, status = "Error", error = result.StatusDetail });
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return Json(new { datas = 0, status = "Error", error = ex.Message });
            }
        }

        public async Task<JsonResult> GetDivisions()
        {
            try
            {
                var data = await _divisionService.GetDivisions();
                var dataSorted = data.OrderByDescending(x => x.Id);
                return Json(new { datas = dataSorted, tcount = dataSorted.Count(), status = "Successful", error = "" });
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return Json(new { datas = new List<Division>(), tcount = 0, status = "Error", error = ex.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> DeleteDivision(int id)
        {
            try
            {
                var result = await _divisionService.DeleteDivision(id);

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
    }
}