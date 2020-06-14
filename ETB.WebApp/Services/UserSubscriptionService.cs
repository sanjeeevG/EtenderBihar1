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
    public class UserSubscriptionService
    {
        IOptions<ApplicationSettings> _appSettings;
        public UserSubscriptionService(IOptions<ApplicationSettings> appSettings)
        {
            _appSettings = appSettings;
        }

        public async Task<IList<UserSubscription>> GetUserSubscriptionByUserId (int userdetailid)
        {
            try
            {
                var url = _appSettings.Value.Api + $"api/UserSubscriptions";
                IDictionary<string, string> headerKeyValuePairs = new Dictionary<string, string>();
                var data =  await Utility.GetStringAsync<UserSubscription>(url, headerKeyValuePairs);
                var results = data.Where(x => x.UserDetail.Id == userdetailid).OrderByDescending(x => x.Id);
                if (results != null )
                {
                    return results.ToList();
                }
                else
                {
                    return new List<UserSubscription>();
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return new List<UserSubscription>();
            }
        }

        public async Task<StatusResult> SaveUserSubscription(UserSubscription userSubscription)
        {
            try
            {
                //updating user info & user detail
                IDictionary<string, string> headerKeyValuePairs = new Dictionary<string, string>();

                var url = _appSettings.Value.Api + "api/UserSubscriptions";
                var resultUSub = await Utility.PostDataAsync<UserSubscription>(url, userSubscription, headerKeyValuePairs);


                if (resultUSub.StatusCode == System.Net.HttpStatusCode.Created ||
                    resultUSub.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var returnedstr = resultUSub.Content.ReadAsStringAsync().Result;

                    return new StatusResult()
                    {
                        Status = Enum.GetName(typeof(StatusText), StatusText.Successful),
                        StatusDetail = "User Subscription has been created.",
                        Data = returnedstr,
                        Content = resultUSub.Content
                    };
                }
                else
                {
                    return new StatusResult()
                    {
                        Status = Enum.GetName(typeof(StatusText), StatusText.Error),
                        StatusDetail = "User Subscription creation failed.",
                        Data = string.Empty,
                        Content = resultUSub.Content
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
