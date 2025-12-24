using System;
using System.Collections.Generic;

namespace WebApplication1.UniversityModels;

public partial class Instructor
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Image { get; set; } = null!;

    public decimal Salary { get; set; }

    public string Address { get; set; } = null!;

    public int CourseId { get; set; }

    public int DepartmentId { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Department Department { get; set; } = null!;
}
