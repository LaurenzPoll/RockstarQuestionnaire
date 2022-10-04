using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using RockstarsHealthCheck.Models;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace RockstarsHealthCheck.Controllers
{
    public class QuestionaireController : Controller
    {
        private readonly string connectionString = @"Server=tcp:rockstars.database.windows.net,1433;Initial Catalog=RockstarsDataBase;Persist Security Info=False;User ID=RockstarAdmin;Password=Rockstars!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        // is to connect to database
        //private readonly RockstarsHealthCheckContext _context;
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

        public IActionResult Question(QuestionViewModel viewModel)
        {
            return View(viewModel);
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

        [HttpGet("[action]")]
        public IActionResult End()
        {
            return View(new QuestionViewModel()) ;
        }

        [HttpPost("[action]")]
        public IActionResult End(QuestionViewModel viewModel)
        {
            using var connection = new SqlConnection(connectionString);

            connection.Open();

            foreach (Question question in viewModel.Questions)
            {
                var command = new SqlCommand(" insert into Answers" + 
                    "\nvalues " +
                    "\n( "  + 4 + " , " + question.Id + " , " + question.AnswerString + " , " + question.Answer + " )", connection);
                var reader = command.ExecuteReader();
            }

            connection.Close();

            return View();
        }
    }
}
