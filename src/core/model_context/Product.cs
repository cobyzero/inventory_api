using System;
using System.Collections.Generic;

namespace inventory_api.src.core.model_context;

public partial class Product
{
    public int ProductId { get; set; }

    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;

    public double ProductWeight { get; set; }

    public string Warehouse { get; set; } = null!;

    public int Stock { get; set; }

    public int UnitMeasureId { get; set; }

    public virtual ICollection<ProductEntry> ProductEntries { get; set; } = new List<ProductEntry>();

    public virtual ICollection<ProductOutput> ProductOutputs { get; set; } = new List<ProductOutput>();

    public virtual UnitMeasure UnitMeasure { get; set; } = null!;
}
