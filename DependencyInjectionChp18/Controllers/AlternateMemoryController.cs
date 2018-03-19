//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using DependencyInjectionChp18.Models;
//using DependencyInjectionChp18.Models.InterfaceDi;
//using Microsoft.AspNetCore.Mvc;

//namespace DependencyInjectionChp18.Controllers
//{
//    public class AlternateMemoryController : Controller
//    {
//        private IMemoryFactory memoryFactoryObj;
//        private IRepository _memoryRepository;
//        public AlternateMemoryController(IMemoryFactory memoryFactory)
//        {
//            memoryFactoryObj = memoryFactory;
//            _memoryRepository = memoryFactoryObj.Create(nameof(AlternateMemoryController));
//        }
//        public IActionResult Index()
//        {
//            ViewBag.ProductList = _memoryRepository.FetchProducts();
//            return View();
//        }
//    }
//}