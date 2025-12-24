using System;
using System.Collections.Generic;

namespace WebApplication1.UniversityModels;

public partial class RoomReservation
{
    public int ReservationId { get; set; }

    public int? ClassroomId { get; set; }

    public string? ReservedBy { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public string? Purpose { get; set; }

    public virtual Classroom? Classroom { get; set; }
}
