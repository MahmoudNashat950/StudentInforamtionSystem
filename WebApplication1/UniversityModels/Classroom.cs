using System;
using System.Collections.Generic;

namespace WebApplication1.UniversityModels;

public partial class Classroom
{
    public int ClassroomId { get; set; }

    public string RoomNumber { get; set; } = null!;

    public int Capacity { get; set; }

    public string? RoomType { get; set; }

    public virtual ICollection<MaintenanceRequest> MaintenanceRequests { get; set; } = new List<MaintenanceRequest>();

    public virtual ICollection<RoomReservation> RoomReservations { get; set; } = new List<RoomReservation>();
}
