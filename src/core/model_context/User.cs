using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace inventory_api.src.core.model_context;

public partial class User : IdentityUser
{
    public required string Name { get; set; }
    public required string DocumentNumber { get; set; }

    public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; } =
        new List<InventoryTransaction>();
}
