using System;
using System.Collections.Generic;

namespace WebApplication1.UniversityModels;

public partial class Value
{
    public int ValueId { get; set; }

    public int EntityId { get; set; }

    public int AttributeId { get; set; }

    public string? AttributeValue { get; set; }

    public virtual Attribute Attribute { get; set; } = null!;

    public virtual Entity Entity { get; set; } = null!;
}
