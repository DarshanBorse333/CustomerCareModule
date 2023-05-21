using CustomerCareModule.Models;

namespace CustomerCareModule.BAL
{
    public interface IManagerService
    {
        ManagerDashboardViewModel GetDashBoardData();
        List<ComplaintViewModel> GetComplaints(int status);
    }
}
