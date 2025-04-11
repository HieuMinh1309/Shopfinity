using System;
using System.Collections.Generic;

namespace SSE_Project.Models;

public partial class ProductImg
{
    public int Id { get; set; }

    public string? ImgUrl { get; set; }

    public int? ProductId { get; set; }

    public virtual Product? Product { get; set; }
}
