using System;
using System.Collections.Generic;

namespace SSE_Project.Models;

public partial class Comment
{
    public int Id { get; set; }

    public string? Content { get; set; }

    public int? ProductId { get; set; }

    public int? CustomerId { get; set; }

    public int? ParentId { get; set; }

    public int? EmployeeId { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Comment> InverseParent { get; set; } = new List<Comment>();

    public virtual Comment? Parent { get; set; }

    public virtual Product? Product { get; set; }
}
