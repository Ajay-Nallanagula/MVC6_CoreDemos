using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RoutingMVC6.Controllers
{
    public class RouteTestController : Controller
    {
        public IActionResult Index(string month, string weekday,int? day)
        {
            ViewBag.Month = month;
            ViewBag.WeekDay = weekday;
            ViewBag.Day = day;
            return View();
        }
    }
}