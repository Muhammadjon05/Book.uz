using BookShop.Domain.Enums;
using BookShop.Service.PaginationModels;

namespace BookShop.Service.Filter;

public class OrderFilter : PaginationParams
{
    public int? Quantity { get; set; }
    public decimal? TotalPrice { get; set; }
    public PaymentMethod? PaymentMethod { get; set; }
    public PaymentStatus? PaymentStatus { get; set; }
}