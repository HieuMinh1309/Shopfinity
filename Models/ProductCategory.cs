using System;
using System.Collections.Generic;

namespace SSE_Project.Models;

public partial class ProductCategory
{
    public int Id { get; set; }

    public string? CateName { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
