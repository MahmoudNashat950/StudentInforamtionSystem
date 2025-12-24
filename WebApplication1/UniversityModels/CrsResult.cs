using System;
using System.Collections.Generic;

namespace WebApplication1.UniversityModels;

public partial class CrsResult
{
    public int Id { get; set; }

    public int Degree { get; set; }

    public int CourseId { get; set; }

    public int TraineeId { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Trainee Trainee { get; set; } = null!;
}
