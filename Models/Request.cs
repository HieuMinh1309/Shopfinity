using System;
using System.Collections.Generic;

namespace SSE_Project.Models;

public partial class Request
{
    public string? EmployeeId { get; set; }

    public int Id { get; set; }

    public string? Name { get; set; }

    public DateOnly? Date { get; set; }

    public string? Status { get; set; }

    public int? WarehouseId { get; set; }

    public string? Type { get; set; }

    public int? OrderId { get; set; }

    public virtual ICollection<RequestDetail> RequestDetails { get; set; } = new List<RequestDetail>();

    public virtual ICollection<WarehouseReleasenote> WarehouseReleasenotes { get; set; } = new List<WarehouseReleasenote>();
}
