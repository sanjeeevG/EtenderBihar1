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
using Serilog;

namespace ETB.WebApp.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IOptions<ApplicationSettings> _appSettings;
        private readonly ISession _session;
        private readonly IHostingEnvironment _environment;
        private readonly DepartmentService _deptService;
        private readonly StateService _stateSerice;


        public DepartmentsController(IOptions<ApplicationSettings> appSettings,
             IHttpContextAccessor httpContextAccessor,
             IHostingEnvironment environment,
             DepartmentService deptService,
             StateService stateSerice )
        {
            _appSettings = appSettings;
            _session = httpContextAccessor.HttpContext.Session;
            _environment = environment;
            _deptService = deptService;
            _stateSerice = stateSerice;
        }

        public async Task<IActionResult> Index()
        {

            ViewData["Title"] = $"{_appSettings.Value.AppTitle}-{Subtitle.DepartmentList}";
            var NoOfRowsSelItemLst = ExternalUtility.GetNoOfSelectItemList(_appSettings.Value.NoOfRowsOptions, _appSettings.Value.DefaultOptionRowSel);
            var deptVM = new DeptViewModel()
            {
                Department1 = "",
                SelState = _appSettings.Value.DefaultSelState,
                States = await _stateSerice.GetStateSelectList(),
                NoOfRows = NoOfRowsSelItemLst
            };
            return View(deptVM);
        }

        public async Task<JsonResult> GetDepartments()
        {
            try
            {
                var data = await _deptService.GetDepartments();
                var dataSorted = data.OrderByDescending(x => x.Id);
                return Json(new { datas = dataSorted, tcount = dataSorted.Count(), status = "Successful", error = "" });
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return Json(new { datas = new List<Department>(), tcount = 0, status = "Error", error = ex.Message });
            }

        }

        public async Task<JsonResult> UpdateDepartment(DeptViewModel deptViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    string message = "Please enter required data.";
                    TempData.Put("notify", new StatusResult() { Status = StatusText.Error.ToString(), StatusDetail = message });
                    ModelState.AddModelError("", message);
                    return Json(new { datas = "", tcount = 0, rcount = 0, status = "Error", message = "Error" });
                }
                else
                {

                    var dept = new Department()
                    {
                        Id = 0,
                        DeptBelongsTo = deptViewModel.SelState,
                        Deptartment = deptViewModel.Department1,
                        CreatedBy = _session.GetString("UserId"),
                        CreationDate = DateTime.Now
                    };

                    var result = await _deptService.SaveNewDepartment(dept);
                    if (result.Status == StatusText.Successful.ToString())
                    {
                        return Json(new { datas = "", tcount = 0, rcount = 0, status = "Successful", message = result.StatusDetail });
                    }
                    else
                    {
                        return Json(new { datas = "", tcount = 0, rcount = 0, status = "Error", message = result.StatusDetail });
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return Json(new { datas = "", status = "Error", error = ex.Message });
            }

        }

        public async Task<JsonResult> GetAutoCompDept(AutoCompParamModelView autoCompParam)
        {
            try
            {
                var depts = await _deptService.GetDepartments();
                var strListDepts = depts.Select(x => x.Deptartment).Distinct<string>();
                var filtDepts = (from dept in strListDepts
                                 where dept.ToLower().StartsWith(autoCompParam.prefix.ToLower())
                                 select new
                                 {
                                     label = dept,
                                     val = dept
                                 }).ToList();

                var filtDepts2 = (from dept in strListDepts
                                  where dept.ToLower().Contains(autoCompParam.prefix.ToLower()) && !dept.ToLower().StartsWith(autoCompParam.prefix.ToLower())
                                  select new
                                  {
                                      label = dept,
                                      val = dept
                                  }).ToList();

                filtDepts.AddRange(filtDepts2);
                return Json(filtDepts);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return Json(new List<Department>());
            }
            
        }

        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> DeleteDepartment(int id)
        {
            try
            {
                var result = await _deptService.DeleteDepartment(id);

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