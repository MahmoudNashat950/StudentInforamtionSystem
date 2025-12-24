using System;
using System.Collections.Generic;

namespace WebApplication1.UniversityModels;

public partial class Transcript
{
    public int TranscriptId { get; set; }

    public int? StudentId { get; set; }

    public DateTime? GeneratedDate { get; set; }

    public virtual Trainee? Student { get; set; }
}
