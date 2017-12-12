using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoutingMVC6.Model;

namespace RoutingMVC6.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View("Result", new Result { Controller = nameof(CustomerController), Action = nameof(Index) });
        }
    }
}