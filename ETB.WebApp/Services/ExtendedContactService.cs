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
    public class ExtendedContactService
    {
        IOptions<ApplicationSettings> _appSettings;
        public ExtendedContactService(IOptions<ApplicationSettings> appSettings)
        {
            _appSettings = appSettings;
        }

        public async Task<IList<ExternalContact>> GetExternalContacts()
        {
            var url = _appSettings.Value.Api + $"api/ExternalContacts";
            IDictionary<string, string> headerKeyValuePairs = new Dictionary<string, string>();
            var resultUI = await Utility.GetStringAsync<ExternalContact>(url, headerKeyValuePairs);
            return resultUI;
        }

        public async Task<StatusResult> SaveUsers(List<ExternalContact> exContacts)
        {
            try
            {
                //updating user info & user detail
                IDictionary<string, string> headerKeyValuePairs = new Dictionary<string, string>();

                var url = _appSettings.Value.Api + "api/ExternalContacts";
                var resultUD = await Utility.PostDataAsync<List<ExternalContact>>(url, exContacts, headerKeyValuePairs);


                if (resultUD.StatusCode == System.Net.HttpStatusCode.Created ||
                    resultUD.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return new StatusResult()
                    {
                        Status = Enum.GetName(typeof(StatusText), StatusText.Successful),
                        StatusDetail = "Extended contacts has been created.",
                        Data = string.Empty,
                        Content = resultUD.Content
                    };
                }
                else
                {
                    return new StatusResult()
                    {
                        Status = Enum.GetName(typeof(StatusText), StatusText.Error),
                        StatusDetail = "Extended Contact creation failed.",
                        Data = string.Empty,
                        Content = resultUD.Content
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
