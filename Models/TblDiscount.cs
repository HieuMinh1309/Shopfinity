using System;
using System.Collections.Generic;

namespace SSE_Project.Models;

public partial class TblDiscount
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public decimal? DiscountPercentage { get; set; }

    public decimal? DiscountAmount { get; set; }

    public DateOnly? ExpiryDate { get; set; }

    public decimal? MinOrderValue { get; set; }

    public decimal? MaxDiscountAmount { get; set; }

    public int? EmployeeId { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
