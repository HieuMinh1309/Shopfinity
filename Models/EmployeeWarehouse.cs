using System;
using System.Collections.Generic;

namespace SSE_Project.Models;

public partial class EmployeeWarehouse
{
    public int Id { get; set; }

    public int? EmployeeId { get; set; }

    public int? WarehouseId { get; set; }

    public virtual Warehouse? Warehouse { get; set; }
}
