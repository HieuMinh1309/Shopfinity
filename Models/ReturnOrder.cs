using System;
using System.Collections.Generic;

namespace SSE_Project.Models;

public partial class ReturnOrder
{
    public int Id { get; set; }

    public int? OrderId { get; set; }

    public DateTime? ReturnDate { get; set; }

    public string? Status { get; set; }

    public string? Note { get; set; }

    public decimal? TotalAmount { get; set; }

    public decimal? DiscountAmount { get; set; }

    public int? EmployeeId { get; set; }

    public string? Message { get; set; }

    public decimal? FinalAmount { get; set; }

    public virtual Order? Order { get; set; }

    public virtual ICollection<ReturnOrderDetail> ReturnOrderDetails { get; set; } = new List<ReturnOrderDetail>();
}
