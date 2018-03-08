using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedRoutingChp16.Controllers
{
    public class TestSecondController : Controller
    {
        public IActionResult DifferentControllerActionMethod()
        {
            ViewBag.ControllerName = this.ControllerContext.RouteData.Values["controller"]?.ToString();
            ViewBag.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            return View();
        }

        public void RenderHtml404()
        {
            Response.Redirect("CustomRoutePageNotFound.html");
        }
    }
}