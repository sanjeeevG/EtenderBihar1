using ETB.Core.Entities;
using ETB.WebApp.Utilities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETB.WebApp.Services
{
    public class DistrictService
    {
        IOptions<ApplicationSettings> _appSettings;
        public DistrictService(IOptions<ApplicationSettings> appSettings)
        {
            _appSettings = appSettings;
        }

        public async Task<IList<District>> GetDistricts()
        {
            try
            {
                var url = _appSettings.Value.Api + $"api/Districts";
                IDictionary<string, string> headerKeyValuePairs = new Dictionary<string, string>();
                return await Utility.GetStringAsync<District>(url, headerKeyValuePairs);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return new List<District>();
            }
        }

        public async Task<IList<SelectListItem>> GetDistrictSelectList()
        {
            try
            {
                var url = _appSettings.Value.Api + $"api/Districts";
                IDictionary<string, string> headerKeyValuePairs = new Dictionary<string, string>();
                var districts =  await Utility.GetStringAsync<District>(url, headerKeyValuePairs);

                var selectedLits = districts.Select(x => new SelectListItem() { Text = x.DistrictName, Value = x.DistrictName }).ToList();

                return selectedLits;

            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return new List<SelectListItem>();
            }
        }

    }
}
