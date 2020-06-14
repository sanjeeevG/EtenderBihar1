using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ETB.Utilities.SMS
{
    public class SMSSender : ISMSSender
    {
        private readonly SMSSettings _smsSettings;
        private readonly IHostingEnvironment _env;

        public SMSSender(
            IOptions<SMSSettings> emailSettings,
            IHostingEnvironment env)
        {
            _smsSettings = emailSettings.Value;
            _env = env;
        }
        
        public async Task SendSMSAV1sync(string toCommSepNumber, string message)
        {
            try
            {
                var client = new HttpClient();
                var strUrl = $"{_smsSettings.UrlV1}?authkey={_smsSettings.AuthKey}&mobiles={toCommSepNumber}&country={_smsSettings.CountryCode}&message={message}&sender={_smsSettings.SenderV1}&route={_smsSettings.Route}";
                var result = await client.GetAsync(new Uri(strUrl,UriKind.Absolute));
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task SendSMSAV2sync(string toCommSepNumber, string message)
        {
            try
            {
                string contentType = "application/json";
                var client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));
                client.DefaultRequestHeaders.Add("authkey", _smsSettings.AuthKey);

                
                var smsarr = new List<sms>() {
                    new sms()
                    {
                    message = message,
                    to = toCommSepNumber.Split(",")
                    }
                }.ToArray();


                var data = new SMSData()
                {
                    sender = _smsSettings.Sender,
                    route = _smsSettings.Route,
                    country = _smsSettings.CountryCode,
                    sms = smsarr
                };

                var myContent = JsonConvert.SerializeObject(data);
                var buffer = Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);

                HttpContent body = new StringContent(myContent);
                body.Headers.ContentType = new MediaTypeHeaderValue(contentType);

                var result = await client.PostAsync(new Uri(_smsSettings.Url), body);

                

                var content = result.Content.ReadAsStringAsync().Result;



                if (result.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    throw new Exception(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

    }
}
