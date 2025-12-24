using System;
using System.Collections.Generic;

namespace WebApplication1.UniversityModels;

public partial class ResourceAllocation
{
    public int AllocationId { get; set; }

    public int? ResourceId { get; set; }

    public string? AllocatedToType { get; set; }

    public int? AllocatedToId { get; set; }

    public DateTime? AllocationDate { get; set; }

    public virtual Resource? Resource { get; set; }
}
