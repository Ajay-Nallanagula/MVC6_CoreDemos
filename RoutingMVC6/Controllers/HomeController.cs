using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoutingMVC6.Model;

namespace RoutingMVC6.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var result = new Result {Controller = nameof(HomeController), Action = nameof(Index)};
            if (RouteData.Values?["id"] != null)
            {
                result.RouteCustomData["id"] = RouteData.Values["id"].ToString();
            }
            return View("Result", result);
        }

        public IActionResult SecondActionMethod(string id)
        {
            var result = new Result { Controller = nameof(HomeController), Action = nameof(Index) };
            result.RouteCustomData["id"] = string.IsNullOrWhiteSpace(id) ? null : id;
            return View("Result", result);
        }

        public IActionResult ThirdActionMethod()
        {
            var result = new Result { Controller = nameof(HomeController), Action = nameof(ThirdActionMethod) };
            if (RouteData.Values?["id"] != null)
            {
                result.RouteCustomData["id"] = RouteData.Values["id"].ToString();
            }
            return View("Result", result);
        }

        public IActionResult ThirdActionMethodWithParameter(string id)
        {
            var result = new Result { Controller = nameof(HomeController), Action = nameof(ThirdActionMethod) };
            result.RouteCustomData["id"] = String.IsNullOrWhiteSpace(id) ? null : id;
            return View("Result", result);
        }

        public IActionResult CatchAllAction(string id)
        {
            var result = new Result { Controller = nameof(HomeController), Action = nameof(ThirdActionMethod) };
            result.RouteCustomData.Add("id",String.IsNullOrWhiteSpace("id")?null:id);
            result.RouteCustomData.Add("catchall", RouteData?.Values["catchall"]?.ToString());
            return View("Result", result);
        }
    }
}