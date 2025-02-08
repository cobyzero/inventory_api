using System;
using System.Collections.Generic;

namespace inventory_api.src.core.model_context;

public partial class Task
{
    public int TaskId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
