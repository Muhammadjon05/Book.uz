using BookShop.Service.PaginationModels;

namespace BookShop.Service.Filter;

public class CategoryFilter : PaginationParams
{
    public string? Name { get; set; }
}