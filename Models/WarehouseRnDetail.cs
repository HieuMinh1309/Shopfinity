using System;
using System.Collections.Generic;

namespace SSE_Project.Models;

public partial class WarehouseRnDetail
{
    public int Id { get; set; }

    public int WgrnId { get; set; }

    public string? Status { get; set; }

    public int? IdProduct { get; set; }

    public int? StockId { get; set; }

    public int? Quantity { get; set; }

    public virtual Stock? Stock { get; set; }

    public virtual WarehouseReleasenote Wgrn { get; set; } = null!;
}
