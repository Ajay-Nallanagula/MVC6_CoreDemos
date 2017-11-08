using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace TypesOfMiddleware.Infrastructure
{
    //ResponseMiddleware
    public class ErrorMiddleware
    {
        private RequestDelegate nextDelegate;

        public ErrorMiddleware(RequestDelegate next)
        {
            nextDelegate = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await nextDelegate.Invoke(context); // This is necessary as first statement because the request pipeline has to be by passed and sent to next middleware, because Response middle ware will deal with response and the response has to be the latest one always 
            if (context.Response.StatusCode == 404)
            {
              await context.Response.WriteAsync("Resource Not found");
            }
            
        }
    }
}
