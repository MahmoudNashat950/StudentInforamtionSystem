using System;
using System.Collections.Generic;

namespace WebApplication1.UniversityModels;

public partial class Entity
{
    public int EntityId { get; set; }

    public string EntityType { get; set; } = null!;

    public int OriginalId { get; set; }

    public virtual ICollection<Value> Values { get; set; } = new List<Value>();
}
