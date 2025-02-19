using System;
using System.Collections.Generic;

namespace inventory_api.src.core.model_context;

public partial class InventoryTransaction
{
    public int TransactionId { get; set; }

    public int? ProductId { get; set; }

    public string TransactionType { get; set; } = null!;

    public int Quantity { get; set; }

    public DateTime TransactionDate { get; set; }

    public string? UserId { get; set; }

    public virtual Product? Product { get; set; }

    public virtual User? User { get; set; }
}
