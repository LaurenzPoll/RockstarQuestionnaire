using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RockstarsHealthCheck.Models;

namespace RockstarsHealthCheck.Controllers
{
    public class QuestionaireController : Controller
    {
        private DataBase _dataBase = new DataBase();

        public IActionResult Index()
        {
            int questionnaireId = 2;
            string url = Request.GetDisplayUrl();
            if (url.Contains("/index/"))
            {
                questionnaireId = (Int32)url[url.Length - 1];
            }
            QuestionViewModel vm = new QuestionViewModel();
            vm.GetQuestions(questionnaireId);
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