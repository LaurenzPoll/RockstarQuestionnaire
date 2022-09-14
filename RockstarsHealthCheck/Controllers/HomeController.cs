using Microsoft.AspNetCore.Mvc;
using RockstarsHealthCheck.Models;
using System.Diagnostics;

namespace RockstarsHealthCheck.Controllers
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

        [HttpPost]
        public IActionResult Checkpoint()
        {
            Date date = new Date();
            date.checkpoint = DateTime.Now;
            date.DateTimeDataBase();
            date.GetLatestDate();
            //date.latestDateTime;

            return View("Index", date);
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