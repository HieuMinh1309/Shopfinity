using System;
using System.Collections.Generic;

namespace SSE_Project.Models;

public partial class SalaryType
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? IsActive { get; set; }

    public virtual ICollection<EmployeeSalaryHistory> EmployeeSalaryHistories { get; set; } = new List<EmployeeSalaryHistory>();
}
