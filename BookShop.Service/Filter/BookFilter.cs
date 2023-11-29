using BookShop.Service.PaginationModels;

namespace BookShop.Service.Filter;

public class BookFilter : PaginationParams
{
    public string? Name { get; set; }
    public int?  PageSize { get; set; }
    public decimal? Price { get; set; }
}