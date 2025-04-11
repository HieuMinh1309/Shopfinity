using System;
using System.Collections.Generic;

namespace SSE_Project.Models;

public partial class Stock
{
    public int Id { get; set; }

    public int? IdProduct { get; set; }

    public int? Quantity { get; set; }

    public string? Status { get; set; }

    public int? WhRcDtId { get; set; }

    public virtual Product? IdProductNavigation { get; set; }

    public virtual ICollection<WarehouseRnDetail> WarehouseRnDetails { get; set; } = new List<WarehouseRnDetail>();

    public virtual WarehouseReceiptDetail? WhRcDt { get; set; }
}
