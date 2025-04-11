using System;
using System.Collections.Generic;

namespace SSE_Project.Models;

public partial class WarehouseReleasenote
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateOnly? Date { get; set; }

    public string? Status { get; set; }

    public string? WarehouseId { get; set; }

    public string? EmployeeId { get; set; }

    public int? RequestId { get; set; }

    public int? OrderId { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Request? Request { get; set; }

    public virtual ICollection<WarehouseRnDetail> WarehouseRnDetails { get; set; } = new List<WarehouseRnDetail>();
}
