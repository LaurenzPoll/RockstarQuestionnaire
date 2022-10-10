//using AspNetCore;
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

        public IActionResult MailUrl()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult MailUrl(MailingViewModel mail)
        {
            mail.link = URL.GenerateQuestionnaireURL(1);
            mail.SendMail();

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}