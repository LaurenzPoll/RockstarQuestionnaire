using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace RockstarsHealthCheck.Controllers
{
    public class QuestionaireController : Controller
    {
        // is to connect to database
        //private readonly RockstarsHealthCheckContext _context;

        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Index([Bind("UserId,Email")] User user)
        //{
            //User myUser = _context.User.FirstOrDefault(u => u.Email.Equals(Email));
            //if (myUser != null && Verify(user.Email, myUser.Email))
            //{
                //return RedirectToAction("Question");
            //}
            //return View();
        //}

        public IActionResult Question()
        {
            //if (Question != null)
            //{
                //return RedirectToAction("End");
            //}
            return View();
        }

        public IActionResult End()
        {
            return View();
        }
    }
}
