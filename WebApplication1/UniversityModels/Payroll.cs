using System;
using System.Collections.Generic;

namespace WebApplication1.UniversityModels;

public partial class Payroll
{
    public int PayrollId { get; set; }

    public int? StaffId { get; set; }

    public decimal? Salary { get; set; }

    public DateTime? PayDate { get; set; }

    public virtual Staff? Staff { get; set; }
}
