using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace ETB.Core.Entities
{
    public enum StatusText
    {
        Successful,
        Error, 
        Info,
        UnHandledError
    }

    public class StatusResult
    {
        public string Status { get; set; }
        public string StatusDetail { get; set; }
        public string Data { get; set; }
        public HttpContent Content { get; set; }
        public string Location { get; set; }
    }
}
