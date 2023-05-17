using System;
using System.Collections.Generic;

namespace CustomerCareModule.DAL;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public int? RoleId { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Complaint> Complaints { get; set; } = new List<Complaint>();

    public virtual Role? Role { get; set; }
}
