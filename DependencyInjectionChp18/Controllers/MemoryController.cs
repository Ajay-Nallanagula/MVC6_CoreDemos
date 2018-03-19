//using DependencyInjectionChp18.Models;
//using DependencyInjectionChp18.Models.InterfaceDi;
//using Microsoft.AspNetCore.Mvc;

//namespace DependencyInjectionChp18.Controllers
//{
//    public class MemoryController : Controller
//    {
//        private IMemoryFactory memoryFactoryObj;
//        private IRepository _memoryRepository;

//        public MemoryController(IMemoryFactory memoryFactory)
//        {
//            memoryFactoryObj = memoryFactory;
//            _memoryRepository = memoryFactoryObj.Create(nameof(MemoryController));

//        }
//        public IActionResult Index()
//        {
//            ViewBag.ProductList = _memoryRepository.FetchProducts();
//            return View();
//        }
//    }
//}