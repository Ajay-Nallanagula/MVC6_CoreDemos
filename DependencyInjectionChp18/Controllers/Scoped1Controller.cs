using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DependencyInjectionChp18.Models.InterfaceDi;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionChp18.Controllers
{
    public class Scoped1Controller : Controller
    {
        private readonly IRepository _repository;

        public Scoped1Controller(IRepository repo)
        {
            _repository = repo;
        }

        public IActionResult Index()
        {
            ViewBag.scopedRepo = _repository.ToString();
            return View();
        }
    }
}