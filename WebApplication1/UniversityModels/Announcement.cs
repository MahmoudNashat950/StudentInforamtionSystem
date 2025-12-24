using System;
using System.Collections.Generic;

namespace WebApplication1.UniversityModels;

public partial class Announcement
{
    public int AnnouncementId { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }
}
