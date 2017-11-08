using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace TypesOfMiddleware.Infrastructure
{
    public class ShortCircuitMiddleware
    {
        private RequestDelegate nextDelegate;

        public ShortCircuitMiddleware(RequestDelegate next)
        {
            nextDelegate = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Trace.WriteLine(this.GetType().ToString());
            //if (context.Request.Headers["User-Agent"].Any(p=>p.ToLower().Contains("chrome"))) //This condition can be simplified when we can make use of Request Editing Middleware.
            if (context.Items["Browser"] as bool? == true)
            {
                context.Response.StatusCode = 403;
            }
            else
            {
                await nextDelegate(context); //You need not use.Invoke() its a delegate "Invoke()" will be called automatically by framework
            }
        }
    }
}
