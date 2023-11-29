using BookShop.Domain.Enums;

namespace BookShop.Domain.DtoModels;

public class OrderDto
{
    public Guid BookId { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
}