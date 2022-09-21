using Microsoft.AspNetCore.Mvc;

namespace RockstarsHealthCheck.Controllers
{
    public class URLController : Controller
    {
        public IActionResult Index(int questionaireID)
        {
            Console.WriteLine(questionaireID);
            return Redirect(".../Questionaire/Index/" + questionaireID.ToString());
        }
    }
}
