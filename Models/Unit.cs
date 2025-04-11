using System;
using System.Collections.Generic;

namespace SSE_Project.Models;

public partial class Unit
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Conversion> ConversionFromUnits { get; set; } = new List<Conversion>();

    public virtual ICollection<Conversion> ConversionToUnits { get; set; } = new List<Conversion>();
}
