using System;
using System.Collections.Generic;

namespace WebApplication1.UniversityModels;

public partial class AdmissionApplication
{
    public int ApplicationId { get; set; }

    public string? StudentName { get; set; }

    public string? NationalId { get; set; }

    public string? ApplicationStatus { get; set; }

    public DateTime? SubmissionDate { get; set; }
}
