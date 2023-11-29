using BookShop.Web.Enums;
using BookShop.Web.PaginationModels;

namespace BookShop.Web.Filter;

public class OrderFilter : PaginationParams
{
    public int? Quantity { get; set; }
    public decimal? TotalPrice { get; set; }
    public PaymentMethod? PaymentMethod { get; set; }
    public PaymentStatus? PaymentStatus { get; set; }
}