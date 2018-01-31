using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace RoutingMVC6.CustomRoute
{
    public class MonthRouteContraint : IRouteConstraint
    {
        private IList<string> MonthList { get; set; }

        public MonthRouteContraint()
        {
            MonthList = new List<string>()
            {
                "Jan",
                "Feb",
                "Mar",
                "Apr",
                "May",
                "Jun",
                "Jul",
                "Aug",
                "Sep",
                "Oct",
                "Nov",
                "Dec"
            };
        }
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            return MonthList.Contains(values[routeKey]?.ToString());
        }
    }
}
