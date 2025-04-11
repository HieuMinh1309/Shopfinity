using System;
using System.Collections.Generic;

namespace SSE_Project.Models;

public partial class Feedback
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public int? OrderDetailId { get; set; }

    public int? Rating { get; set; }

    public string? Comment { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? Status { get; set; }

    public virtual Product? Product { get; set; }
}
