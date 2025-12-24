using System;
using System.Collections.Generic;

namespace WebApplication1.UniversityModels;

public partial class Attribute
{
    public int AttributeId { get; set; }

    public string AttributeName { get; set; } = null!;

    public virtual ICollection<Value> Values { get; set; } = new List<Value>();
}
