using System;
using System.Collections.Generic;

namespace SSE_Project.Models;

public partial class Conversion
{
    public int Id { get; set; }

    public int? FromUnitId { get; set; }

    public int? ToUnitId { get; set; }

    public int? ProductId { get; set; }

    public int? ConversionRate { get; set; }

    public virtual Unit? FromUnit { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Unit? ToUnit { get; set; }
}
