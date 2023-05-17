using CustomerCareModule.Models;

namespace CustomerCareModule.BAL
{
    public interface ICustomerCareService
    {
        string RegisterComplaint(ComplaintViewModel complaintViewModel);
    }
}
