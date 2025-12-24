using System;
using System.Collections.Generic;

namespace WebApplication1.UniversityModels;

public partial class Laboratory
{
    public int LabId { get; set; }

    public string? LabName { get; set; }

    public int? Capacity { get; set; }
}
