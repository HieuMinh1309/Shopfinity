using System;
using System.Collections.Generic;

namespace SSE_Project.Models;

public partial class Customer
{
    public string? LastName { get; set; }

    public DateTime? CreationTime { get; set; }

    public string? Address { get; set; }

    public string? Password { get; set; }

    public DateTime? Dob { get; set; }

    public string? Email { get; set; }

    public string? FirstName { get; set; }

    public int Id { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; } = new List<ShoppingCart>();
}
