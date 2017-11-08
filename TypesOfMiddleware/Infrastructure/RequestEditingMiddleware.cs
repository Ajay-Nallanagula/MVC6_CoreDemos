using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace TypesOfMiddleware.Infrastructure
{
    public class RequestEditingMiddleware
    {
        private RequestDelegate nextdelegate;

        public RequestEditingMiddleware(RequestDelegate next)
        {
            
            nextdelegate = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Trace.WriteLine(this.GetType().ToString());
            context.Items["Browser"] = false;//!context.Request.Headers["User-Agent"].Any(p => p.ToLower().Contains("chrome"));
            context.Items["IsContainsMiddleware"] = context.Request.Path.ToString().ToLower() == "/middleware";
            await nextdelegate(context);
        }
    }
}
