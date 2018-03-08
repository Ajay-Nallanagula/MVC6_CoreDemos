using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdvancedRoutingChp16.Models;

namespace AdvancedRoutingChp16.Controllers
{
    public class HomeController : Controller
    {
        public string ActionName { get; set; }

        public string ControllerName { get; set; }
        public HomeController()
        {
           
        }

        public IActionResult Index()
        {
            ViewBag.ControllerName = this.ControllerContext.RouteData.Values["controller"]?.ToString();
            ViewBag.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            return View();
        }

        public IActionResult ActionMethodInSameController()
        {
            ViewBag.ControllerName = this.ControllerContext.RouteData.Values["controller"]?.ToString();
            ViewBag.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            return View();
        }
    }
}
