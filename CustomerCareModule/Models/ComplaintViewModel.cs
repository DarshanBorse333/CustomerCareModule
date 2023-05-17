namespace CustomerCareModule.Models
{
    public class ComplaintViewModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? MobileNumber { get; set; }

        public string? Description { get; set; }

        public int? StatusId { get; set; }

        public DateTime? DateOfRegistration { get; set; }

        public DateTime? DateOfAction { get; set; }

        public int? UserId { get; set; }

    }
}
