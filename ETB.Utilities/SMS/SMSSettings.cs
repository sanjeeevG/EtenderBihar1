using System;
using System.Collections.Generic;
using System.Text;

namespace ETB.Utilities.SMS
{
    public class SMSSettings
    {
        public string Url { get; set; }
        public string UrlV1 { get; set; }
        public string AuthKey { get; set; }
        public string Sender { get; set; }
        public string SenderV1 { get; set; }
        public string Route { get; set; }
        public string CountryCode { get; set; }
    }
}
