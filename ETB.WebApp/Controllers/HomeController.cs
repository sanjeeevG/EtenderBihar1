using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ETB.WebApp.Models;
using ETB.Core.Entities;
using ETB.WebApp.Services;
using Microsoft.Extensions.Options;
using ETB.WebApp.Utilities;
using Microsoft.AspNetCore.Authorization;

namespace ETB.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly SMSSenderService _smsSenderService;
        private readonly IOptions<ApplicationSettings> _appSettings;
        public HomeController(IOptions<ApplicationSettings> appSettings,
            SMSSenderService smsSenderService)
        {
            _smsSenderService = smsSenderService;
            _appSettings = appSettings;
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize(Roles = "Admin, Operator")]
        public IActionResult OtherTools()
        {
            return View();
        }

        [Authorize(Roles = "Admin, Operator")]
        public IActionResult SmsSenderTool()
        {
            var entity = new SMSViewModel();
            return View(entity);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Operator")]
        public IActionResult SmsSenderTool(SMSViewModel sMSViewModel)
        {
            if (!ModelState.IsValid)
            {
                string message = "Please enter required data.";
                ModelState.AddModelError("", message);
                return View(sMSViewModel);
            }
            else
            {
                _smsSenderService.SendSMSNotification(sMSViewModel.CommaSepToNum, sMSViewModel.Message);
            }
            return View(sMSViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
