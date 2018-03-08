using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AdvancedRoutingChp16.CustomConstraints
{
    public class WeekDayRouteConstraint : IRouteConstraint
    {
        public List<string> WeekDays { get; set; }
        public WeekDayRouteConstraint()
        {
            WeekDays = new List<string> {"Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"};
        }

        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            return WeekDays.Contains(values[routeKey]?.ToString());
        }
    }
}
