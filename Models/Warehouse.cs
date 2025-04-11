using System;
using System.Collections.Generic;

namespace SSE_Project.Models;

public partial class Warehouse
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? WardId { get; set; }

    public int? ProvinceId { get; set; }

    public int? GhnStoreId { get; set; }

    public int? DistrictId { get; set; }

    public decimal? Lat { get; set; }

    public decimal? Lng { get; set; }

    public int WhTypeId { get; set; }

    public virtual ICollection<WarehouseReceipt> WarehouseReceipts { get; set; } = new List<WarehouseReceipt>();

    public virtual WarehouseType WhType { get; set; } = null!;
}
