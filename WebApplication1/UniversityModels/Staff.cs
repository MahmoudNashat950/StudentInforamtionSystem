using System;
using System.Collections.Generic;

namespace WebApplication1.UniversityModels;

public partial class Staff
{
    public int StaffId { get; set; }

    public string? Name { get; set; }

    public string? Role { get; set; }

    public int? DepartmentId { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public virtual Department? Department { get; set; }

    public virtual ICollection<LeaveRequest> LeaveRequests { get; set; } = new List<LeaveRequest>();

    public virtual ICollection<Payroll> Payrolls { get; set; } = new List<Payroll>();
}
