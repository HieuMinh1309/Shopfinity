using System;
using System.Collections.Generic;

namespace SSE_Project.Models;

public partial class TaxHistory
{
    public int Id { get; set; }

    public string? TaxType { get; set; }

    public DateOnly? PeriodStart { get; set; }

    public DateOnly? PeriodEnd { get; set; }

    public decimal? Amount { get; set; }

    public decimal? TaxRate { get; set; }

    public decimal? TaxAmount { get; set; }

    public string? PaymentStatus { get; set; }

    public DateOnly? PaymentDate { get; set; }

    public string? Note { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }
}
