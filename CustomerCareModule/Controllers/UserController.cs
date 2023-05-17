using Microsoft.AspNetCore.Mvc;

namespace CustomerCareModule.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
