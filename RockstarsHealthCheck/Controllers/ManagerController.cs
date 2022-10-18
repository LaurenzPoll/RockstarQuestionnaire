using Microsoft.AspNetCore.Mvc;

namespace RockstarsHealthCheck.Controllers
{
    public class ManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
