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
    public class StateService
    {
        IOptions<ApplicationSettings> _appSettings;
        public StateService(IOptions<ApplicationSettings> appSettings)
        {
            _appSettings = appSettings;
        }

        public async Task<IList<State>> GetStates()
        {
            try
            {
                var url = _appSettings.Value.Api + $"api/States";
                IDictionary<string, string> headerKeyValuePairs = new Dictionary<string, string>();
                return await Utility.GetStringAsync<State>(url, headerKeyValuePairs);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return new List<State>();
            }
        }

        public async Task<IList<SelectListItem>> GetStateSelectList()
        {
            try
            {
                var url = _appSettings.Value.Api + $"api/States";
                IDictionary<string, string> headerKeyValuePairs = new Dictionary<string, string>();
                var states = await Utility.GetStringAsync<State>(url, headerKeyValuePairs);

                var selectedLits = states.Select(x => new SelectListItem() { Text = x.Name, Value = x.Name }).ToList();

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
