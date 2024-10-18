using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Zurex.Models;

namespace Zurex.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About() 
        { 
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult PropertyList()
        {
            return View();
        }

        public IActionResult PropertyAgent()
        {
            return View();
        }

        public IActionResult PropertyType()
        {
            return View();
        }

        public IActionResult Testimonial()
        {
            return View();
        }

        public IActionResult Error404()
        {
            return View();
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
