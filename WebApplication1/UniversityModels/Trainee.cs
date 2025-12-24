using System;
using System.Collections.Generic;

namespace WebApplication1.UniversityModels;

public partial class Trainee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Image { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int Grade { get; set; }

    public int DepartmentId { get; set; }

    public virtual ICollection<CrsResult> CrsResults { get; set; } = new List<CrsResult>();

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Transcript> Transcripts { get; set; } = new List<Transcript>();
}
