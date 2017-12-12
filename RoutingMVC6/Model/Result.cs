using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoutingMVC6.Model
{
    public class Result
    {
        public string Controller { get; set; }
        public string Action { get; set; }

        public Dictionary<string,string> RouteCustomData { get; set; }

        public Result()
        {
            RouteCustomData = new Dictionary<string, string>();
        }
    }
}
