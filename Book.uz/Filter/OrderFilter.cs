using Book.uz.Enums;
using Book.uz.PaginationModels;

namespace Book.uz.Filter;

public class OrderFilter : PaginationParams
{
    public int? Quantity { get; set; }
    public decimal? TotalPrice { get; set; }
    public PaymentMethod? PaymentMethod { get; set; }
    public PaymentStatus? PaymentStatus { get; set; }
}