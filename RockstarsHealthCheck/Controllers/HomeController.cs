//using AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            //DataBase data = new DataBase();
            //ViewBag.QuestionnairreList = data.GetAllQuestionnaires();
            MailingViewModel mail = new MailingViewModel();
            QuestionnairesViewModel questionnaires = new QuestionnairesViewModel();
            DataBase data = new DataBase();

            mail.FillQuestionnaireList();

            SelectList selectList = new SelectList(data.GetAllQuestionnaires());

            return View(mail);
        }
        
        [HttpPost]
        public IActionResult MailUrl(MailingViewModel mail)
        {
            /*
            mail.link = URL.GenerateQuestionnaireURL(1);
            mail.SendMail();
            */

            return Ok("De ingetypte mail: " + mail.toEmail + "\nDe gekozen questionnaire: " +mail.linkID);
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
                return RedirectToAction("Index", "Manager");
            }
            else
            {
                ViewBag.Text = "Incorrect email/password";
                return View("Index");
            }
        }
    }
}