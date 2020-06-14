using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ETB.WebApp.Utilities
{
    public static class Utility
    {
        public static async Task<IList<T>> GetStringAsync<T>(string url, IDictionary<string, string> headers)
        {
            using (var httpClient = new HttpClient())
            {
                foreach (var data in headers)
                {
                    httpClient.DefaultRequestHeaders.Add(data.Key, data.Value);
                }
                var strData = await httpClient.GetStringAsync(url);

                return JsonConvert.DeserializeObject<IList<T>>(strData);
            }
        }

        public static async Task<T> GetEntityAsync<T>(string url, IDictionary<string, string> headers)
        {
            using (var httpClient = new HttpClient())
            {
                foreach (var data in headers)
                {
                    httpClient.DefaultRequestHeaders.Add(data.Key, data.Value);
                }
                try
                {
                    var strData = await httpClient.GetStringAsync(url);
                    return JsonConvert.DeserializeObject<T>(strData);
                }
                catch (HttpRequestException ex)
                {
                    var aa = ex.Message;
                    return default(T);

                }
                catch (Exception ex)
                {
                    var aa = ex.Message;
                    return default(T);

                }
                
            }
        }

        public static async Task<string> GetStringAsync(string url, IDictionary<string, string> headers)
        {
            using (var httpClient = new HttpClient())
            {
                foreach (var data in headers)
                {
                    httpClient.DefaultRequestHeaders.Add(data.Key, data.Value);
                }
                var strData = await httpClient.GetStringAsync(url);

                return strData;
            }
        }

        public static async Task<HttpResponseMessage> PostDataAsync<T>(string url, T t, IDictionary<string, string> headers)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    foreach (var data in headers)
                    {
                        httpClient.DefaultRequestHeaders.Add(data.Key, data.Value);
                    }

                    var myContent = JsonConvert.SerializeObject(t);
                    var buffer = Encoding.UTF8.GetBytes(myContent);
                    var byteContent = new ByteArrayContent(buffer);

                    var responseMessage = await httpClient.PostAsJsonAsync<T>(url, t);

                    return responseMessage;
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return null;
            }
        }

        public static async Task<HttpResponseMessage> UpdateDataAsync<T>(string url, T t, IDictionary<string, string> headers)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    foreach (var data in headers)
                    {
                        httpClient.DefaultRequestHeaders.Add(data.Key, data.Value);
                    }

                    var myContent = JsonConvert.SerializeObject(t);
                    var buffer = Encoding.UTF8.GetBytes(myContent);
                    var byteContent = new ByteArrayContent(buffer);

                    var responseMessage = await httpClient.PutAsJsonAsync<T>(url, t);

                    return responseMessage;
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return null;
            }
        }

        public static async Task<HttpResponseMessage> DeleteDataAsync<T>(string url, IDictionary<string, string> headers)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    foreach (var data in headers)
                    {
                        httpClient.DefaultRequestHeaders.Add(data.Key, data.Value);
                    }

                    //var myContent = JsonConvert.SerializeObject(t);
                    //var buffer = Encoding.UTF8.GetBytes(myContent);
                    //var byteContent = new ByteArrayContent(buffer);

                    var responseMessage = await httpClient.DeleteAsync(url);

                    return responseMessage;
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return null;
            }
        }
    }
}
