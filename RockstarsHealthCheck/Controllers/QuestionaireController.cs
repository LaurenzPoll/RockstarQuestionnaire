using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using RockstarsHealthCheck.Models;
using System.ComponentModel.DataAnnotations;

namespace RockstarsHealthCheck.Controllers
{
    public class QuestionaireController : Controller
    {
        // is to connect to database
        //private readonly RockstarsHealthCheckContext _context;
        string? Email;
        List<Question>? Questions;

        public IActionResult Index()
        {
            return View();
        }

        /*[HttpPost] // is used to post things to the server
        public IActionResult Index([Bind("UserId,Email")] Users users)
        {
            Users myUser = _context.Users.FirstOrDefault(u => u.Email.Equals(email));
            if (myUser != null && Verify(users.Email, myUser.Email))
            {
                return RedirectToAction("Question");
            }
            return View();
        }*/

        public IActionResult Question(string email)
        {
            Email = email;
            ViewBag.email = Email;
            return View();
        }

        /*[HttpPost]
        public IActionResult Question([Bind("UserId, QuestionId, Answer, AnswerRange")] Answers answers)
        {
            Answers.UserId = Users.UserId;
            if ()
            {
                return RedirectToAction("End");
            }
            return View();
        }*/

        public IActionResult End(string email)
        {
            Email = email;
            ViewBag.email = Email;
            return View();
        }
    }
}
