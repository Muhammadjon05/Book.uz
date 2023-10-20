﻿using Book.uz.Enums;

namespace Book.uz.Entities;

public class Order
{
    public Guid OrderId { get; set; }
    public Guid BookId { get; set; }
    public virtual Book Book { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public virtual ICollection<UserOrder> UsersOrders { get; set; }
}