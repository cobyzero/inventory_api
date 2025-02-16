using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace inventory_api.src.core.model_context;

public partial class User : IdentityUser
{
    public int UserId { get; set; }

    public string FullName { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string DocumentNumber { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public int PermissionId { get; set; }

    public virtual Permission Permission { get; set; } = null!;

    public virtual ICollection<ProductEntry> ProductEntries { get; set; } =
        new List<ProductEntry>();

    public virtual ICollection<ProductOutput> ProductOutputs { get; set; } =
        new List<ProductOutput>();
}
