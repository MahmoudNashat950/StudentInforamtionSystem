using System;
using System.Collections.Generic;

namespace WebApplication1.UniversityModels;

public partial class Course
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int degree { get; set; }

    public int Mindegree { get; set; }

    public int departmentId { get; set; }

    public virtual ICollection<CrsResult> CrsResults { get; set; } = new List<CrsResult>();

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<Course> Prerequisites { get; set; } = new List<Course>();
}
