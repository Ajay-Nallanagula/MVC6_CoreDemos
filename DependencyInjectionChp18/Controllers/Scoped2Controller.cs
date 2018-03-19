using DependencyInjectionChp18.Models.InterfaceDi;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionChp18.Controllers
{
    public class Scoped2Controller : Controller
    {
        private readonly IScopedRepository _scopedRepository;
        private readonly IDemoRepository _demoRepository;

        public Scoped2Controller(IScopedRepository scopedRepo,IDemoRepository demoRepo)
        {
            _scopedRepository = scopedRepo;
            _demoRepository = demoRepo;
        }

        public IActionResult Index()
        {
            ViewBag.scopedRepo = _scopedRepository.ToString();
            ViewBag.demoRepo = _demoRepository.ToString();
            return View();
        }
    }
}