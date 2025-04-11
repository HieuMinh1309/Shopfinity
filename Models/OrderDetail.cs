using System;
using System.Collections.Generic;

namespace SSE_Project.Models;

public partial class OrderDetail
{
    public int Id { get; set; }

    public int? StockId { get; set; }

    public int? OrderId { get; set; }

    public int? ProductId { get; set; }

    public decimal? Price { get; set; }

    public int? Quantity { get; set; }

    public string? Status { get; set; }

    public virtual Order? Order { get; set; }
}
