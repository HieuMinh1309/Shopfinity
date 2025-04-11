using System;
using System.Collections.Generic;

namespace SSE_Project.Models;

public partial class ExpenseHistory
{
    public int Id { get; set; }

    public int? ExpenseTypeId { get; set; }

    public decimal? Amount { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? Note { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ExpenseType? ExpenseType { get; set; }
}
