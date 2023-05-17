using Microsoft.AspNetCore.Mvc;

namespace CustomerCareModule.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
