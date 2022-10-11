using Microsoft.AspNetCore.Mvc;
using RockstarsHealthCheck.Models;

namespace RockstarsHealthCheck.Controllers
{
    public class QuestionaireController : Controller
    {
        private DataBase _dataBase = new DataBase();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Question(QuestionViewModel viewModel)
        {
            return View(viewModel);
        }

        [HttpGet("[action]")]
        public IActionResult End()
        {
            return View(new QuestionViewModel()) ;
        }

        [HttpPost("[action]")]
        public IActionResult End(QuestionViewModel viewModel)
        {
            _dataBase.SendAnswersToDataBase(viewModel);
            return View();
        }
    }
}