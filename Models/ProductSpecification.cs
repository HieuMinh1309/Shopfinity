using System;
using System.Collections.Generic;

namespace SSE_Project.Models;

public partial class ProductSpecification
{
    public int Id { get; set; }

    public string? NameSpe { get; set; }

    public string? DesSpe { get; set; }

    public int? ProductId { get; set; }

    public virtual Product? Product { get; set; }
}
