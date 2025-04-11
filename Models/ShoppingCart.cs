using System;
using System.Collections.Generic;

namespace SSE_Project.Models;

public partial class ShoppingCart
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public int? ProductId { get; set; }

    public string? Status { get; set; }

    public int? Quantity { get; set; }

    public virtual Customer? Customer { get; set; }
}
