using System;
using System.Collections.Generic;

namespace WebApplication1.UniversityModels;

public partial class Resource
{
    public int ResourceId { get; set; }

    public string? ResourceName { get; set; }

    public string? ResourceType { get; set; }

    public int? Quantity { get; set; }

    public virtual ICollection<ResourceAllocation> ResourceAllocations { get; set; } = new List<ResourceAllocation>();
}
