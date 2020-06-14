using Microsoft.AspNetCore.Http;
//using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;

namespace ETB.WebApi.Middleware
{
    public class RequestAuditingMiddleWare
    {
        //private readonly ILogger _logging; 
        private readonly RequestDelegate _nextRequest;

        public RequestAuditingMiddleWare(RequestDelegate next)
        {
            _nextRequest = next;
            //_logging = Log.Logger;
            //_logging = loggerFactory.CreateLogger<RequestAuditingMiddleWare>();
        }

        public async Task Invoke(HttpContext context)
        {
            //modify the request reated value here
            //context.Items["Firefox"] = context.Request.Headers["User-Agent"].Any(v => v.Contains("Firefox"));
            //_logging.LogInformation($"{context.Request.Path}");
            //Log.Logger.Information($"{context.Request.Path}");
            Log.ForContext<RequestAuditingMiddleWare>().Information($"{context.Request.Path}");
            await _nextRequest.Invoke(context);
        }
    }
}
