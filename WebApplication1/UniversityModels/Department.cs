using System;
using System.Collections.Generic;

namespace WebApplication1.UniversityModels;

public partial class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Manager { get; set; } = null!;

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();

    public virtual ICollection<Trainee> Trainees { get; set; } = new List<Trainee>();
}
