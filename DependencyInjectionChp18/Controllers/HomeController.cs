using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DependencyInjectionChp18.Models;
using DependencyInjectionChp18.Models.InterfaceDi;

namespace DependencyInjectionChp18.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repository;
        private IRepository _repository2;
        public HomeController(IRepository repository, IRepository repository2)
        {
            _repository = repository;
            _repository2 = repository2;
        }
        public IActionResult Index()
        {
            ViewBag.HomeController = _repository.ToString();
            ViewBag.repo = _repository.ToString();
            ViewBag.repo1 = _repository2.ToString();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
