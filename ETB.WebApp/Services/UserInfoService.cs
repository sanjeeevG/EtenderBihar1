using ETB.Core.Entities;
using ETB.WebApp.Utilities;
using ETB.Utilities;
using Microsoft.Extensions.Options;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ETB.WebApp.Services
{
    public class UserInfoService
    {
        IOptions<ApplicationSettings> _appSettings;
        public UserInfoService(IOptions<ApplicationSettings> appSettings)
        {
            _appSettings = appSettings;
        }

        public async Task<StatusResult> RegisterNewUser(UserDetail userDetail)
        {
            try
            {
                //updating user info & user detail
                IDictionary<string, string> headerKeyValuePairs = new Dictionary<string, string>();

                var url = _appSettings.Value.Api + "api/UserDetails";
                var resultUD = await Utility.PostDataAsync<UserDetail>(url, userDetail, headerKeyValuePairs);


                if (resultUD.StatusCode == System.Net.HttpStatusCode.Created ||
                    resultUD.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return new StatusResult()
                    {
                        Status = Enum.GetName(typeof(StatusText), StatusText.Successful),
                        StatusDetail = "User Info/Detail has been created.",
                        Data = string.Empty,
                        Content = resultUD.Content
                    };
                }
                else
                {
                    return new StatusResult()
                    {
                        Status = Enum.GetName(typeof(StatusText), StatusText.Error),
                        StatusDetail = "User Info/Detail creation failed.",
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

        public async Task<StatusResult> UpdateUserDetail(int id, UserDetail userDetail)
        {
            try
            {
                //updating user info & user detail
                IDictionary<string, string> headerKeyValuePairs = new Dictionary<string, string>();

                var url = _appSettings.Value.Api + $"api/UserDetails/{id}";
                var resultUD = await Utility.UpdateDataAsync<UserDetail>(url, userDetail, headerKeyValuePairs);


                if (resultUD.StatusCode == System.Net.HttpStatusCode.Created ||
                    resultUD.StatusCode == System.Net.HttpStatusCode.OK ||
                    resultUD.StatusCode == System.Net.HttpStatusCode.Accepted)
                {
                    return new StatusResult()
                    {
                        Status = Enum.GetName(typeof(StatusText), StatusText.Successful),
                        StatusDetail = "User Detail has been modified.",
                        Data = string.Empty,
                        Content = resultUD.Content
                    };
                }
                else
                {
                    return new StatusResult()
                    {
                        Status = Enum.GetName(typeof(StatusText), StatusText.Error),
                        StatusDetail = "User Detail modification failed.",
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

        public async Task<StatusResult> UpdateUserInfo(int id, UserInfo userInfo)
        {
            try
            {
                //updating user info & user detail
                IDictionary<string, string> headerKeyValuePairs = new Dictionary<string, string>();

                var url = _appSettings.Value.Api + $"api/UserInfos/{id}";
                var resultUI = await Utility.UpdateDataAsync<UserInfo>(url, userInfo, headerKeyValuePairs);


                if (resultUI.StatusCode == System.Net.HttpStatusCode.Created ||
                    resultUI.StatusCode == System.Net.HttpStatusCode.OK ||
                    resultUI.StatusCode == System.Net.HttpStatusCode.Accepted)
                {
                    return new StatusResult()
                    {
                        Status = Enum.GetName(typeof(StatusText), StatusText.Successful),
                        StatusDetail = "User Info has been modified.",
                        Data = string.Empty,
                        Content = resultUI.Content
                    };
                }
                else
                {
                    return new StatusResult()
                    {
                        Status = Enum.GetName(typeof(StatusText), StatusText.Error),
                        StatusDetail = "User Info modification failed.",
                        Data = string.Empty,
                        Content = resultUI.Content
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

        public async Task<bool> IsUserIdAlreayExists(string userId)
        {
            var url = _appSettings.Value.Api + $"api/Users/IsUserExists/{userId}";
            IDictionary<string, string> headerKeyValuePairs = new Dictionary<string, string>();
            var resultUI = await Utility.GetStringAsync(url, headerKeyValuePairs);
            return Convert.ToBoolean(resultUI);
        }

        public async Task<StatusResult> ValidateCredentials(UserInfo userInfo)
        {
            try
            {
                var url = _appSettings.Value.Api + "api/ValidateCredentials";
                IDictionary<string, string> headerKeyValuePairs = new Dictionary<string, string>();
                var resultUI = await Utility.PostDataAsync<UserInfo>(url, userInfo, headerKeyValuePairs);

                if (resultUI.StatusCode == System.Net.HttpStatusCode.Created ||
                    resultUI.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return new StatusResult()
                    {
                        Status = Enum.GetName(typeof(StatusText), StatusText.Successful),
                        StatusDetail = "Valid User",
                        Data = string.Empty,
                        Content = resultUI.Content
                    };
                }
                else if (resultUI.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return new StatusResult()
                    {
                        Status = Enum.GetName(typeof(StatusText), StatusText.Error),
                        StatusDetail = "User not found.",
                        Data = string.Empty,
                        Content = resultUI.Content
                    };
                }
                else
                {
                    return new StatusResult()
                    {
                        Status = Enum.GetName(typeof(StatusText), StatusText.Error),
                        StatusDetail = "Invalid User.",
                        Data = string.Empty,
                        Content = resultUI.Content
                    };
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<StatusResult> DeactivateUser(int id)
        {
            try
            {
                var url = _appSettings.Value.Api + $"api/DeActivateUser/{id}";
                IDictionary<string, string> headerKeyValuePairs = new Dictionary<string, string>();
                var resultUI = await Utility.UpdateDataAsync<UserInfo>(url, null, headerKeyValuePairs);

                if (resultUI.StatusCode == System.Net.HttpStatusCode.OK ||
                    resultUI.StatusCode == System.Net.HttpStatusCode.Accepted)
                {
                    return new StatusResult()
                    {
                        Status = Enum.GetName(typeof(StatusText), StatusText.Successful),
                        StatusDetail = $"User [{id}] has been deactivated",
                        Data = string.Empty,
                        Content = resultUI.Content
                    };
                }
                else
                {
                    return new StatusResult()
                    {
                        Status = Enum.GetName(typeof(StatusText), StatusText.Error),
                        StatusDetail = $"Some Error, Couldn't Deactivate User [{id}]",
                        Data = string.Empty,
                        Content = resultUI.Content
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

        public async Task<StatusResult> ActivateUser(int id)
        {
            try
            {
                var url = _appSettings.Value.Api + $"api/ActivateUser/{id}";
                IDictionary<string, string> headerKeyValuePairs = new Dictionary<string, string>();
                var resultUI = await Utility.UpdateDataAsync<UserInfo>(url, null, headerKeyValuePairs);

                if (resultUI.StatusCode == System.Net.HttpStatusCode.OK ||
                    resultUI.StatusCode == System.Net.HttpStatusCode.Accepted)
                {
                    return new StatusResult()
                    {
                        Status = Enum.GetName(typeof(StatusText), StatusText.Successful),
                        StatusDetail = $"User [{id}] has been activated",
                        Data = string.Empty,
                        Content = resultUI.Content
                    };
                }
                else
                {
                    return new StatusResult()
                    {
                        Status = Enum.GetName(typeof(StatusText), StatusText.Error),
                        StatusDetail = $"Some Error, Couldn't activate User [{id}]",
                        Data = string.Empty,
                        Content = resultUI.Content
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

        public async Task<StatusResult> DeleteUser(int id)
        {
            try
            {
                var url = _appSettings.Value.Api + $"api/UserDetails/{id}";
                IDictionary<string, string> headerKeyValuePairs = new Dictionary<string, string>();
                var resultUI = await Utility.DeleteDataAsync<UserDetail>(url, headerKeyValuePairs);

                if (resultUI.StatusCode == System.Net.HttpStatusCode.OK ||
                    resultUI.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return new StatusResult()
                    {
                        Status = Enum.GetName(typeof(StatusText), StatusText.Successful),
                        StatusDetail = $"User [{id}] has been deleted",
                        Data = string.Empty,
                        Content = resultUI.Content
                    };
                }
                else
                {
                    return new StatusResult()
                    {
                        Status = Enum.GetName(typeof(StatusText), StatusText.Error),
                        StatusDetail = $"Some Error, Couldn't delete User [{id}]",
                        Data = string.Empty,
                        Content = resultUI.Content
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

        public async Task<IList<UserDetail>> GetUserDetails()
        {
            var url = _appSettings.Value.Api + $"api/UserDetails";
            IDictionary<string, string> headerKeyValuePairs = new Dictionary<string, string>();
            var resultUI = await Utility.GetStringAsync<UserDetail>(url, headerKeyValuePairs);
            return resultUI;
        }

        public async Task<IList<UserDetail>> GetActiveUserDetails()
        {
            var url = _appSettings.Value.Api + $"api/AUserDetails";
            IDictionary<string, string> headerKeyValuePairs = new Dictionary<string, string>();
            var resultUI = await Utility.GetStringAsync<UserDetail>(url, headerKeyValuePairs);
            return resultUI;
        }

        public async Task<IList<UserDetail>> GetDeActiveUserDetails()
        {
            var url = _appSettings.Value.Api + $"api/DAUserDetails";
            IDictionary<string, string> headerKeyValuePairs = new Dictionary<string, string>();
            var resultUI = await Utility.GetStringAsync<UserDetail>(url, headerKeyValuePairs);
            return resultUI;
        }

        public async Task<UserDetail> GetUserInfoDetails(string userId)
        {
            try
            {
                var url = _appSettings.Value.Api + $"api/UserInfoDetail/{userId}";
                IDictionary<string, string> headerKeyValuePairs = new Dictionary<string, string>();
                var resultUI = await Utility.GetEntityAsync<UserDetail>(url, headerKeyValuePairs);
                return resultUI;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<UserDetail> GetUserDetailById(int id)
        {
            var url = _appSettings.Value.Api + $"api/UserDetails/{id}";
            IDictionary<string, string> headerKeyValuePairs = new Dictionary<string, string>();
            var resultUI = await Utility.GetEntityAsync<UserDetail>(url, headerKeyValuePairs);
            return resultUI;
        }

        public async Task<StatusResult> SaveSigninLog(UserSignInLog userSignInLog)
        {
            try
            {
                //updating user info & user detail
                IDictionary<string, string> headerKeyValuePairs = new Dictionary<string, string>();

                var url = _appSettings.Value.Api + "api/UserSignInLogs";
                var result = await Utility.PostDataAsync<UserSignInLog>(url, userSignInLog, headerKeyValuePairs);


                if (result.StatusCode == System.Net.HttpStatusCode.Created ||
                    result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return new StatusResult()
                    {
                        Status = Enum.GetName(typeof(StatusText), StatusText.Successful),
                        StatusDetail = "User Signing log entry has been created.",
                        Data = string.Empty,
                        Content = result.Content
                    };
                }
                else
                {
                    return new StatusResult()
                    {
                        Status = Enum.GetName(typeof(StatusText), StatusText.Error),
                        StatusDetail = "User Signing log entry creation failed.",
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
