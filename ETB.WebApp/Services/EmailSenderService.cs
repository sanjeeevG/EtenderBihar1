using ETB.Utilities;
using ETB.Utilities.Email;
using ETB.WebApp.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ETB.WebApp.Services
{
    public class EmailSenderService
    {
        private readonly IOptions<ApplicationSettings> _appSettings;
        private readonly IHostingEnvironment _environment;
        private readonly IEmailSender _emailSender;

        public EmailSenderService(IOptions<ApplicationSettings> appSettings,
            IHostingEnvironment environment,
            IEmailSender emailSender)
        {
            _appSettings = appSettings;
            _emailSender = emailSender;
            _environment = environment;
        }

        public void SendCreateAcountEmailNotification(string name, string userId, string sendersEmail, string lPageUrl, string serviceurl, string subject)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", _appSettings.Value.EmailCreateAccountStausTemp);
            string filePathLogo = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", _appSettings.Value.LogoUrl);
            //string lPageUrl = _appSettings.Value.LoginPageUrl;
            
            string tempContent = ExternalUtility.GetFileContent(filePath);

            string emailContent = string.Format(tempContent, name, userId, lPageUrl, serviceurl);
            _emailSender.SendEmailAsync(sendersEmail, subject, emailContent, filePathLogo);
        }

        public void SendForgotPassEmailNotification(string userId, string sendersEmail, string url, string subject)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", _appSettings.Value.EmailForgotPassTemp);
            string filePathLogo = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", _appSettings.Value.LogoUrl);
            //string lPageUrl = _appSettings.Value.LoginPageUrl;
            string tempContent = ExternalUtility.GetFileContent(filePath);

            string emailContent = string.Format(tempContent, userId, url);
            _emailSender.SendEmailAsync(sendersEmail, subject, emailContent, filePathLogo);
        }

    }
}
