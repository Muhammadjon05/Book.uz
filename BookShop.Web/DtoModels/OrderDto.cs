using BookShop.Web.Enums;

namespace BookShop.Web.DtoModels;

public class OrderDto
{
    public Guid BookId { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
}