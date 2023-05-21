using CustomerCareModule.BAL;
using Microsoft.AspNetCore.Mvc;

namespace CustomerCareModule.Controllers
{
    public class ManagerController : Controller
    {

        private readonly IManagerService managerService;

        public ManagerController(IManagerService _managerService)
        {
            this.managerService = _managerService;
        }
        public IActionResult Index()
        {
            var managerDashBoardViewModel = managerService.GetDashBoardData();
            return View(managerDashBoardViewModel);
        }

        public IActionResult ComplaintList(int status)
        {


            var complaintViewModels = managerService.GetComplaints(status);
            return View(complaintViewModels);
        }


    }
}
