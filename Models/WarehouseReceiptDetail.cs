using System;
using System.Collections.Generic;

namespace SSE_Project.Models;

public partial class WarehouseReceiptDetail
{
    public int Id { get; set; }

    public int? WhReceiptId { get; set; }

    public decimal? WhPrice { get; set; }

    public string? Status { get; set; }

    public int? ProductId { get; set; }

    public string? ConversionId { get; set; }

    public int? Quantity { get; set; }

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();

    public virtual WarehouseReceipt? WhReceipt { get; set; }
}
