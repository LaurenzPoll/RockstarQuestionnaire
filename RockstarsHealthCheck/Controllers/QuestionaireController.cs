using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using RockstarsHealthCheck.Models;

namespace RockstarsHealthCheck.Controllers
{
    public class QuestionaireController : Controller
    {
        private DataBase _dataBase = new DataBase();

        public IActionResult Index(int ID)
        {
            if (ID == 0)
            {
                ID = 2;
            }
            QuestionViewModel vm = new QuestionViewModel();
            vm.GetQuestions(ID);
            return View(vm);
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