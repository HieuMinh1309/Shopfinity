using System;
using System.Collections.Generic;

namespace SSE_Project.Models;

public partial class WarehouseReceipt
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? WhId { get; set; }

    public string? Status { get; set; }

    public string? EmployeeId { get; set; }

    public decimal? TotalFee { get; set; }

    public decimal? OtherFee { get; set; }

    public decimal? ShippingFee { get; set; }

    public DateTime? Date { get; set; }

    public virtual ICollection<WarehouseReceiptDetail> WarehouseReceiptDetails { get; set; } = new List<WarehouseReceiptDetail>();

    public virtual Warehouse? Wh { get; set; }
}
