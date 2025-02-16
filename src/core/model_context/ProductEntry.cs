using System;
using System.Collections.Generic;

namespace inventory_api.src.core.model_context;

public partial class ProductEntry
{
    public int EntryId { get; set; }

    public string DocumentNumber { get; set; } = null!;

    public DateOnly RegisterDate { get; set; }

    public int RegisteredBy { get; set; }

    public string ClientDocument { get; set; } = null!;

    public string ClientName { get; set; } = null!;

    public int CompanyId { get; set; }

    public int ProductId { get; set; }

    public string Warehouse { get; set; } = null!;

    public int ProductQuantity { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual User RegisteredByNavigation { get; set; } = null!;
}
