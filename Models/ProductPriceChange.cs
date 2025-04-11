using System;
using System.Collections.Generic;

namespace SSE_Project.Models;

public partial class ProductPriceChange
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public decimal? Price { get; set; }

    public DateTime? DateStart { get; set; }

    public DateTime? DateEnd { get; set; }

    public virtual Product Product { get; set; } = null!;
}
