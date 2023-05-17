using CustomerCareModule.DAL;
using CustomerCareModule.Models;

namespace CustomerCareModule.BAL
{
    public class CustomerCareService : ICustomerCareService
    {
        private readonly ProjectContext db;

        public CustomerCareService(ProjectContext _db)
        {
            this.db = _db;
        }

        public string RegisterComplaint(ComplaintViewModel complaintViewModel)
        {
            Complaint complaint = new Complaint();
            complaint.Name = complaintViewModel.Name;
            complaint.Email = complaintViewModel.Email;
            complaint.MobileNumber = complaintViewModel.MobileNumber;
            complaint.Description = complaintViewModel.Description;
            complaint.DateOfRegistration = DateTime.Now;
            complaint.DateOfAction = DateTime.Now;
            complaint.StatusId = 1;
            

            db.Complaints.Add(complaint);
            db.SaveChanges();

            return "";
        }
    }
}
