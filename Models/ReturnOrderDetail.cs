using System;
using System.Collections.Generic;

namespace SSE_Project.Models;

public partial class ReturnOrderDetail
{
    public int Id { get; set; }

    public int? ReturnOrderId { get; set; }

    public int? OrderDetailId { get; set; }

    public int? Quantity { get; set; }

    public string? Reason { get; set; }

    public decimal? Amount { get; set; }

    public virtual ReturnOrder? ReturnOrder { get; set; }
}
