using System;
using System.Collections.Generic;

namespace SSE_Project.Models;

public partial class WarehouseType
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
}
