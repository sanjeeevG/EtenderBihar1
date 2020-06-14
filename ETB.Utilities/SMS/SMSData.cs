using System;
using System.Collections.Generic;
using System.Text;

namespace ETB.Utilities.SMS
{
    public class SMSData
    {
        public string sender { get; set; }
        public string route { get; set; }
        public string country { get; set; }
        public sms[] sms { get; set; }
    }

    public class sms
    {
        public string message { get; set; }
        public string[] to { get; set; } 
    }
}
