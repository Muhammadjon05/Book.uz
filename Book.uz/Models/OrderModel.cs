using Book.uz.Entities;
using Book.uz.Enums;

namespace Book.uz.Models;

public class OrderModel
{
    public Guid OrderId { get; set; }
    public Guid BookId { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public Guid UserId { get; set; }
}