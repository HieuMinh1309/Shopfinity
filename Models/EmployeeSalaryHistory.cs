using System;
using System.Collections.Generic;

namespace SSE_Project.Models;

public partial class EmployeeSalaryHistory
{
    public int Id { get; set; }

    public int? EmployeeId { get; set; }

    public int? SalaryTypeId { get; set; }

    public decimal? Amount { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? Note { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual SalaryType? SalaryType { get; set; }
}
