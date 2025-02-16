using System;
using System.Collections.Generic;

namespace inventory_api.src.core.model_context;

public partial class Permission
{
    public int PermissionId { get; set; }

    public string Description { get; set; } = null!;

    public bool AllowExits { get; set; }

    public bool AllowEntries { get; set; }

    public bool AllowProducts { get; set; }

    public bool AllowUsers { get; set; }

    public bool AllowSuppliers { get; set; }

    public bool AllowInventory { get; set; }

    public bool AllowConfig { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
