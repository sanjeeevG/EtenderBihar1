using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ETB.Utilities.Email
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string emails, string subject, string message, string logourl);
    }
}
