using ETB.Core.Entities;
using ETB.WebApp.Utilities;
using Microsoft.Extensions.Options;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETB.WebApp.Services
{
    public class DepartmentService
    {
        IOptions<ApplicationSettings> _appSettings;
        public DepartmentService(IOptions<ApplicationSettings> appSettings)
        {
            _appSettings = appSettings;
        }

        public async Task<IList<Department>> GetDepartments()
        {
            try
            {
                var url = _appSettings.Value.Api + $"api/Departments";
                IDictionary<string, string> headerKeyValuePairs = new Dictionary<string, string>();
                return await Utility.GetStringAsync<Department>(url, headerKeyValuePairs);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return new List<Department>();
            }
        }

        public async Task<StatusResult> SaveNewDepartment(Department Department)
        {
            try
            {
                //updating user info & user detail
                IDictionary<string, string> headerKeyValuePairs = new Dictionary<string, string>();

                var url = _appSettings.Value.Api + "api/Departments";
                var resultDiv = await Utility.PostDataAsync<Department>(url, Department, headerKeyValuePairs);


                if (resultDiv.StatusCode == System.Net.HttpStatusCode.Created ||
                    resultDiv.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var returnedstr = resultDiv.Content.ReadAsStringAsync().Result;

                    return new StatusResult()
                    {
                        Status = Enum.GetName(typeof(StatusText), StatusText.Successful),
                        StatusDetail = "Department has been created.",
                        Data = returnedstr,
                        Content = resultDiv.Content
                    };
                }
                else
                {
                    return new StatusResult()
                    {
                        Status = Enum.GetName(typeof(StatusText), StatusText.Error),
                        StatusDetail = "Department creation failed.",
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

        public async Task<StatusResult> DeleteDepartment(int id)
        {
            try
            {
                //updating user info & user detail
                IDictionary<string, string> headerKeyValuePairs = new Dictionary<string, string>();

                var url = _appSettings.Value.Api + $"api/Departments/{id}";
                var result = await Utility.DeleteDataAsync<Department>(url, headerKeyValuePairs);


                if (result.StatusCode == System.Net.HttpStatusCode.Created ||
                    result.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return new StatusResult()
                    {
                        Status = Enum.GetName(typeof(StatusText), StatusText.Successful),
                        StatusDetail = $"Department [{id}] has been deleted",
                        Data = string.Empty,
                        Content = result.Content
                    };
                }
                else
                {
                    return new StatusResult()
                    {
                        Status = Enum.GetName(typeof(StatusText), StatusText.Error),
                        StatusDetail = $"Some Error, Couldn't delete the Department [{id}]",
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
