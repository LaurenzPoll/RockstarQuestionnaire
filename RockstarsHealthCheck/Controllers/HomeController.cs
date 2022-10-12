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
            Date date = new Date();
            date.GetLatestDate();
            ViewBag.latest = date.latestDateTime;

            return View();
        }

        [HttpPost]
        public IActionResult Checkpoint()
        {
            Date date = new Date();

            date.GetLatestDate();
            ViewBag.latest = date.latestDateTime;
            date.checkpoint = DateTime.Now;
            date.DateTimeDataBase();

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

        [HttpPost]
        public IActionResult LogIn(string emailTB, string passwordTB)
        {
            string email = emailTB;
            string password = passwordTB;

            LoginDatabase database = new LoginDatabase();

            if(database.LogIn(email, password) == true)
            {
                Console.WriteLine("succes");
                return View("Privacy");
            }
            else
            {
                ViewBag.Text = "Incorrect email/password";
                return View("Index");
            }
        }
    }
}