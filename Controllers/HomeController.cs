using Microsoft.AspNetCore.Mvc;
using RealEstateWebsite.Models;
using System.Diagnostics;

namespace RealEstateWebsite.Controllers
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
            //return Content("Welcome to the Real Estate Management System");
        }

        public IActionResult Welcome(string name, int cost)
        {
            //return Content($"Welcome to the Real Estate Management System which shows {name} and + {cost.ToString()}");
            ViewData["Message"] = "Hello" + name;
            ViewData["Cost"] = cost;
            return View();
        }

        public IActionResult Privacy()
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