using ETB.Utilities.SMS;
using ETB.WebApp.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETB.WebApp.Services
{
    public class SMSSenderService
    {
        private readonly IOptions<ApplicationSettings> _appSettings;
        private readonly IHostingEnvironment _environment;
        private readonly ISMSSender _smsSender;

        public SMSSenderService(IOptions<ApplicationSettings> appSettings,
            IHostingEnvironment environment,
            ISMSSender smsSender)
        {
            _appSettings = appSettings;
            _smsSender = smsSender;
            _environment = environment;
        }

        public void SendSMSNotification(string commaSepNo, string message)
        {
            try
            {
                _smsSender.SendSMSAV2sync(commaSepNo, message);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
            
        }

        public void SendCreateAcountSMSNotification(string name, string userId, string number, string lPageUrl)
        {
            try
            {



                string message = $"Dear {name}, " +
                             $" You have successfully registered with ETender Bihar using {userId}. " +
                             $" Contact admin @ +91-7903470005 for subscription." +
                             $" Login url: {lPageUrl}. Thank you! Team Etender Bihar.";

                _smsSender.SendSMSAV1sync(number, message);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
        }
    }
}
