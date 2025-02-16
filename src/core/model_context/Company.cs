using System;
using System.Collections.Generic;

namespace inventory_api.src.core.model_context;

public partial class Company
{
    public int CompanyId { get; set; }

    public string BusinessName { get; set; } = null!;

    public string Ruc { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual ICollection<ProductEntry> ProductEntries { get; set; } = new List<ProductEntry>();
}
