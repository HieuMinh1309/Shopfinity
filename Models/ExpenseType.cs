using System;
using System.Collections.Generic;

namespace SSE_Project.Models;

public partial class ExpenseType
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? IsFixed { get; set; }

    public string? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<ExpenseHistory> ExpenseHistories { get; set; } = new List<ExpenseHistory>();
}
