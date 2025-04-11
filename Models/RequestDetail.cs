using System;
using System.Collections.Generic;

namespace SSE_Project.Models;

public partial class RequestDetail
{
    public int? QuantityExported { get; set; }

    public int Id { get; set; }

    public int? RequestId { get; set; }

    public string? Status { get; set; }

    public int? IdProduct { get; set; }

    public int? QuantityRequested { get; set; }

    public virtual Request? Request { get; set; }
}
