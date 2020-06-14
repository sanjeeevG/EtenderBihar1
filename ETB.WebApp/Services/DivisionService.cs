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
    public class DivisionService
    {
        IOptions<ApplicationSettings> _appSettings;
        public DivisionService(IOptions<ApplicationSettings> appSettings)
        {
            _appSettings = appSettings;
        }

        public async Task<IList<Division>> GetDivisions()
        {
            try
            {
                var url = _appSettings.Value.Api + $"api/Divisions";
                IDictionary<string, string> headerKeyValuePairs = new Dictionary<string, string>();
                return await Utility.GetStringAsync<Division>(url, headerKeyValuePairs);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return new List<Division>();
            }
        }

        public async Task<IList<SelectListItem>> GetDivisionSelectList(string district)
        {
            try
            {
                var url = _appSettings.Value.Api + $"api/Divisions";
                IDictionary<string, string> headerKeyValuePairs = new Dictionary<string, string>();
                var districts = await Utility.GetStringAsync<Division>(url, headerKeyValuePairs);

                List<SelectListItem> selectedLits = new List<SelectListItem>();

                if (district.Length != 0)
                    selectedLits = districts.Where(x => x.DistrictName == district).Select(x => new SelectListItem() { Text = x.DivisionName, Value = x.DistrictName }).ToList();
                else
                    selectedLits = districts.Select(x => new SelectListItem() { Text = x.DivisionName, Value = x.DivisionName }).ToList();

                return selectedLits;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return new List<SelectListItem>();
            }
        }

        public async Task<StatusResult> SaveNewDivision(Division division)
        {
            try
            {
                //updating user info & user detail
                IDictionary<string, string> headerKeyValuePairs = new Dictionary<string, string>();

                var url = _appSettings.Value.Api + "api/Divisions";
                var resultDiv = await Utility.PostDataAsync<Division>(url, division, headerKeyValuePairs);


                if (resultDiv.StatusCode == System.Net.HttpStatusCode.Created ||
                    resultDiv.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var returnedstr = resultDiv.Content.ReadAsStringAsync().Result;

                    return new StatusResult()
                    {
                        Status = Enum.GetName(typeof(StatusText), StatusText.Successful),
                        StatusDetail = "Division has been created.",
                        Data = returnedstr,
                        Content = resultDiv.Content
                    };
                }
                else
                {
                    return new StatusResult()
                    {
                        Status = Enum.GetName(typeof(StatusText), StatusText.Error),
                        StatusDetail = "Division creation failed.",
                        Data = string.Empty,
                        Content = resultDiv.Content
                    };
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return new StatusResult()
                {
                    Status = Enum.GetName(typeof(StatusText), StatusText.UnHandledError),
                    StatusDetail = ex.Message,
                    Data = string.Empty,
                    Content = null
                };
            }
        }

        public async Task<StatusResult> DeleteDivision(int id)
        {
            try
            {
                //updating user info & user detail
                IDictionary<string, string> headerKeyValuePairs = new Dictionary<string, string>();

                var url = _appSettings.Value.Api + $"api/Divisions/{id}";
                var result = await Utility.DeleteDataAsync<Division>(url, headerKeyValuePairs);


                if (result.StatusCode == System.Net.HttpStatusCode.Created ||
                    result.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return new StatusResult()
                    {
                        Status = Enum.GetName(typeof(StatusText), StatusText.Successful),
                        StatusDetail = $"Division [{id}] has been deleted",
                        Data = string.Empty,
                        Content = result.Content
                    };
                }
                else
                {


                    return new StatusResult()
                    {
                        Status = Enum.GetName(typeof(StatusText), StatusText.Error),
                        StatusDetail = $"Some Error, Couldn't delete the Division [{id}]",
                        Data = string.Empty,
                        Content = result.Content
                    };
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return new StatusResult()
                {
                    Status = Enum.GetName(typeof(StatusText), StatusText.UnHandledError),
                    StatusDetail = ex.Message,
                    Data = string.Empty,
                    Content = null
                };
            }
        }
    }
}
