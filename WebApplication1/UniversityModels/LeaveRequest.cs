using System;
using System.Collections.Generic;

namespace WebApplication1.UniversityModels;

public partial class LeaveRequest
{
    public int LeaveId { get; set; }

    public int? StaffId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Status { get; set; }

    public virtual Staff? Staff { get; set; }
}
