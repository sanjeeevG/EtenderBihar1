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
    public class ServiceService
    {
        IOptions<ApplicationSettings> _appSettings;
        public ServiceService(IOptions<ApplicationSettings> appSettings)
        {
            _appSettings = appSettings;
        }

        public async Task<IList<Service>> GetServices()
        {
            try
            {
                var url = _appSettings.Value.Api + $"api/AServices";
                IDictionary<string, string> headerKeyValuePairs = new Dictionary<string, string>();
                return await Utility.GetStringAsync<Service>(url, headerKeyValuePairs);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return new List<Service>();
            }
        }

        public async Task<Service> GetServicesById(int id)
        {
            try
            {
                var url = _appSettings.Value.Api + $"api/Services/{id}";
                IDictionary<string, string> headerKeyValuePairs = new Dictionary<string, string>();
                var resultUI = await Utility.GetEntityAsync<Service>(url, headerKeyValuePairs);
                return resultUI;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return new Service();
            }
        }

        public async Task<IList<SelectListItem>> GetServicesSelectList()
        {
            try
            {
                var url = _appSettings.Value.Api + $"api/AServices";
                IDictionary<string, string> headerKeyValuePairs = new Dictionary<string, string>();
                var services =  await Utility.GetStringAsync<Service>(url, headerKeyValuePairs);

                var selectListItem = services.Select(x => new SelectListItem() { Text = $"{x.Name} | {x.Price} | {x.Duration}", Value = x.Id.ToString()}).ToList();

                return selectListItem;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return new List<SelectListItem>();
            }
        }

    }
}
