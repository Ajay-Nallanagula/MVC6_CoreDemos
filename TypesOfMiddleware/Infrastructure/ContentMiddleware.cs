using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace TypesOfMiddleware.Infrastructure
{
    public class ContentMiddleware
    {
        private RequestDelegate nextDelegate;

        public UptimeService uptimeService { get; }

        //We can additionally pass arguments to ctor, which will help in avoiding duplication of code. checkingfff
        public ContentMiddleware(RequestDelegate next , UptimeService upTimeSrvc)
        {
            nextDelegate = next;
            uptimeService = upTimeSrvc;
            
        }

        public async Task Invoke(HttpContext httpContext)
        {
            Trace.WriteLine(this.GetType().ToString());
            //if (httpContext.Request.Path.ToString().ToLower() == "/middleware")
            if (httpContext.Items["IsContainsMiddleware"] as bool? == true) //Changed as part of RequestEditingMiddleware
            {
                //Manipulate the response content
                await httpContext.Response.WriteAsync($"this.GetType().ToString(), TimeTaken : {uptimeService.Uptime()}");
            }
            else
            {
                //Pass to next middleware 
                await nextDelegate.Invoke(httpContext);
            }
        }
    }
}
