using System;
using System.Collections.Generic;

namespace SSE_Project.Models;

public partial class BannedKeyword
{
    public int Id { get; set; }

    public string? Keyword { get; set; }

    public string? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
