using System;
using System.Collections.Generic;

namespace SSE_Project.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Phone { get; set; }

    public string? Password { get; set; }

    public int? RoleId { get; set; }

    public virtual ICollection<EmployeeSalaryHistory> EmployeeSalaryHistories { get; set; } = new List<EmployeeSalaryHistory>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Role? Role { get; set; }
}
