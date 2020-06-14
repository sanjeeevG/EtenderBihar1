using ETB.Core.Entities;
using ETB.WebApp.Models;
using ETB.WebApp.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETB.WebApp.Services
{
    public class TenderService
    {
        IOptions<ApplicationSettings> _appSettings;
        public TenderService(IOptions<ApplicationSettings> appSettings)
        {
            _appSettings = appSettings;
        }

        public List<SelectListItem> GetTenderTypes()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem(){Text = "Open", Value = "Open"},
                new SelectListItem(){Text = "Selective", Value = "Selective"},
                new SelectListItem(){Text = "Negotiation", Value = "Negotiation"},
                new SelectListItem(){Text = "Term", Value = "Term"}
            };
        }

        public async Task<Tender> GetTenderById(int id)
        {
            try
            {
                var url = _appSettings.Value.Api + $"api/Tenders/{id}";
                IDictionary<string, string> headerKeyValuePairs = new Dictionary<string, string>();
                return await Utility.GetEntityAsync<Tender>(url, headerKeyValuePairs);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return new Tender();
            }
        }

        public async Task<IList<Tender>> GetTenderPartialData()
        {
            return await GetTenderData(_appSettings.Value.NoOfRowsAtFrontPage);
        }

        public async Task<IList<Tender>> GetTenderData(string totalRec)
        {
            try
            {
                var url = _appSettings.Value.Api + "api/ATenders";
                var totalRecs = _appSettings.Value.NoOfRowsAtFrontPage;
                IDictionary<string, string> headerKeyValuePairs = new Dictionary<string, string>();
                headerKeyValuePairs[nameof(_appSettings.Value.NoOfRowsAtFrontPage)] = totalRec.ToString();

                return await Utility.GetStringAsync<Tender>(url, headerKeyValuePairs);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return new List<Tender>();
            }
        }

        public async Task<IList<DistrictTenderCountViewModel>> GetDistrictWiseCount()
        {
            try
            {
                var url = _appSettings.Value.Api + "api/ATenders";
                var totalRecs = _appSettings.Value.NoOfRowsAtFrontPage;
                IDictionary<string, string> headerKeyValuePairs = new Dictionary<string, string>
                {
                    [nameof(_appSettings.Value.NoOfRowsAtFrontPage)] = "0"
                };

                var tenders = await Utility.GetStringAsync<Tender>(url, headerKeyValuePairs);

                var distWiseGroupingForTenders = tenders.Where(x => x.BidSubmissionEnDate >= DateTime.Now).GroupBy(x => x.District)
                        .Select(s => new
                        {
                            District = s.Key,
                            Count = s.Count()
                        }).OrderBy(O => O.District);

                //get district
                url = _appSettings.Value.Api + "api/Districts";
                headerKeyValuePairs = new Dictionary<string, string>();
                var districts = await Utility.GetStringAsync<District>(url, headerKeyValuePairs);
                List<DistrictTenderCountViewModel> districtViewModels = new List<DistrictTenderCountViewModel>();

                foreach (var district in districts)
                {
                    var count = 0;
                    count = distWiseGroupingForTenders.Where(x => x.District == district.DistrictName).Select(x => x.Count).SingleOrDefault();

                    districtViewModels.Add(new DistrictTenderCountViewModel
                    {
                        Id = district.Id,
                        State = district.State,
                        District = district.DistrictName,
                        TenderCount = count
                    });
                }

                return districtViewModels.OrderByDescending(x => x.TenderCount).ThenBy(x => x.District).ToList<DistrictTenderCountViewModel>();
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return new List<DistrictTenderCountViewModel>();
            }
        }

        public async Task<StatusResult> SaveNewTender(Tender tender)
        {
            try
            {
                //updating user info & user detail
                IDictionary<string, string> headerKeyValuePairs = new Dictionary<string, string>();

                var url = _appSettings.Value.Api + "api/Tenders";
                var resultUD = await Utility.PostDataAsync<Tender>(url, tender, headerKeyValuePairs);


                if (resultUD.StatusCode == System.Net.HttpStatusCode.Created ||
                    resultUD.StatusCode == System.Net.HttpStatusCode.OK)
                {

                    var returnedstr = resultUD.Content.ReadAsStringAsync().Result;

                    return new StatusResult()
                    {
                        Status = Enum.GetName(typeof(StatusText), StatusText.Successful),
                        StatusDetail = "Tender has been created.",
                        Data = returnedstr,
                        Content = resultUD.Content
                    };
                }
                else
                {
                    return new StatusResult()
                    {
                        Status = Enum.GetName(typeof(StatusText), StatusText.Error),
                        StatusDetail = "Tender creation failed.",
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

        public async Task<StatusResult> UpdateTender(int id, Tender tender)
        {
            try
            {
                //updating user info & user detail
                IDictionary<string, string> headerKeyValuePairs = new Dictionary<string, string>();

                var url = _appSettings.Value.Api + $"api/Tenders/{id}";
                var resultUD = await Utility.UpdateDataAsync<Tender>(url, tender, headerKeyValuePairs);


                if (resultUD.StatusCode == System.Net.HttpStatusCode.Created ||
                    resultUD.StatusCode == System.Net.HttpStatusCode.OK ||
                    resultUD.StatusCode == System.Net.HttpStatusCode.Accepted)
                {

                    var returnedstr = resultUD.Content.ReadAsStringAsync().Result;

                    return new StatusResult()
                    {
                        Status = Enum.GetName(typeof(StatusText), StatusText.Successful),
                        StatusDetail = "Tender has been modified.",
                        Data = returnedstr,
                        Content = resultUD.Content
                    };
                }
                else
                {


                    return new StatusResult()
                    {
                        Status = Enum.GetName(typeof(StatusText), StatusText.Error),
                        StatusDetail = "Tender modification failed.",
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

        public async Task<StatusResult> DeleteTender(int id)
        {
            try
            {
                //updating user info & user detail
                IDictionary<string, string> headerKeyValuePairs = new Dictionary<string, string>();

                var url = _appSettings.Value.Api + $"api/Tenders/{id}";
                var resultUD = await Utility.DeleteDataAsync<Tender>(url,headerKeyValuePairs);


                if (resultUD.StatusCode == System.Net.HttpStatusCode.Created ||
                    resultUD.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return new StatusResult()
                    {
                        Status = Enum.GetName(typeof(StatusText), StatusText.Successful),
                        StatusDetail = $"Tender [{id}] has been deleted",
                        Data = string.Empty,
                        Content = resultUD.Content
                    };
                }
                else
                {


                    return new StatusResult()
                    {
                        Status = Enum.GetName(typeof(StatusText), StatusText.Error),
                        StatusDetail = $"Some Error, Couldn't delete the tender [{id}]",
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
