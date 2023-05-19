using CustomerCareModule.DAL;
using CustomerCareModule.Models;

namespace CustomerCareModule.BAL
{
    public class CustomerCareService : ICustomerCareService
    {
        private readonly ProjectContext db;
        private readonly IHttpContextAccessor ihttpContextAccessor;

        public CustomerCareService(ProjectContext _db,IHttpContextAccessor _ihttpContextAccessor)
        {
            this.db = _db;
            this.ihttpContextAccessor = _ihttpContextAccessor;

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
            complaint.UserId = ihttpContextAccessor.HttpContext.Session.GetInt32("UserId");


            db.Complaints.Add(complaint);
            db.SaveChanges();

            return "";
        }
    }
}
