using System;
using System.Collections.Generic;

namespace inventory_api.src.core.model_context;

public partial class UnitMeasure
{
    public int UnitMeasureId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
