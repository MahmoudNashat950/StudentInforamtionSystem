using System;
using System.Collections.Generic;

namespace WebApplication1.UniversityModels;

public partial class Event
{
    public int EventId { get; set; }

    public string? EventName { get; set; }

    public DateTime? EventDate { get; set; }

    public string? Location { get; set; }

    public string? Description { get; set; }
}
