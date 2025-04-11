using System;
using System.Collections.Generic;

namespace SSE_Project.Models;

public partial class Order
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public string? CusName { get; set; }

    public string? Status { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public int? WarehouseId { get; set; }

    public int? ProvinceId { get; set; }

    public int? DistrictId { get; set; }

    public string? WardId { get; set; }

    public int? GhnOrderCode { get; set; }

    public string? TrackingCode { get; set; }

    public int? EmployeeId { get; set; }

    public string? PayStatus { get; set; }

    public DateOnly? ExpectedDeliveryTime { get; set; }

    public string? ShippingStatus { get; set; }

    public DateTime? Date { get; set; }

    public int? CouponId { get; set; }

    public decimal? Discount { get; set; }

    public decimal? TotalAmount { get; set; }

    public decimal? ShippingFee { get; set; }

    public string? Notes { get; set; }

    public string? OrderId { get; set; }

    public string? TransactionId { get; set; }

    public int? PaymentId { get; set; }

    public virtual ICollection<ChatRoom> ChatRooms { get; set; } = new List<ChatRoom>();

    public virtual TblDiscount? Coupon { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Payment? Payment { get; set; }

    public virtual ICollection<ReturnOrder> ReturnOrders { get; set; } = new List<ReturnOrder>();

    public virtual ICollection<WarehouseReleasenote> WarehouseReleasenotes { get; set; } = new List<WarehouseReleasenote>();
}
