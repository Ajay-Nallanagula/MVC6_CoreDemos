using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite.Internal.PatternSegments;

namespace AdvancedRoutingChp16.CustomRouteConfiguration
{
    public class LegacyRoutes : IRouter
    {
        public string[] UrlList { get; set; }
        public LegacyRoutes(params string[] targetUrls)
        {
            UrlList = targetUrls;
        }

        public Task RouteAsync(RouteContext context)
        {
            var requestedUrl = context.HttpContext.Request.Path.Value.TrimEnd('/');
            if (UrlList.Contains(requestedUrl,StringComparer.OrdinalIgnoreCase))
            {
                context.Handler = CustomRouteHandler;
                //context.Handler = async (contextHttpContext) =>
                //{
                //    var response = contextHttpContext.Response;
                //    var byteArr = Encoding.ASCII.GetBytes($"URL : {requestedUrl}");
                //    await response.Body.WriteAsync(byteArr, 0, byteArr.Length);
                //};
            }
            return Task.CompletedTask;
        }

        private async Task CustomRouteHandler(HttpContext contextHttpContext)
        {
            var requestedUrl = contextHttpContext.Request.Path.Value.TrimEnd('/');
            var response = contextHttpContext.Response;
            var byteArr = Encoding.ASCII.GetBytes($"URL : {requestedUrl}");
            //response.Redirect("/TestSecond/RenderHtml404");
            await response.Body.WriteAsync(byteArr, 0, byteArr.Length);
        }

        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            return null;
        }
    }
}
