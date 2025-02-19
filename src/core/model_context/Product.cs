using System;
using System.Collections.Generic;

namespace inventory_api.src.core.model_context;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public int StockQuantity { get; set; }

    public int? CategoryId { get; set; }

    public int? SupplierId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; } = new List<InventoryTransaction>();

    public virtual Supplier? Supplier { get; set; }
}
