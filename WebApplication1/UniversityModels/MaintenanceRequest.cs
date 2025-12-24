using System;
using System.Collections.Generic;

namespace WebApplication1.UniversityModels;

public partial class MaintenanceRequest
{
    public int RequestId { get; set; }

    public int? ClassroomId { get; set; }

    public string? IssueDescription { get; set; }

    public string? Status { get; set; }

    public DateTime? ReportedDate { get; set; }

    public virtual Classroom? Classroom { get; set; }
}
