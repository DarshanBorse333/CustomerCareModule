using Microsoft.AspNetCore.Mvc;

namespace CustomerCareModule.Controllers
{
    public class ManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
