using BookShop.Web.PaginationModels;

namespace BookShop.Web.Filter;

public class CategoryFilter : PaginationParams
{
    public string? Name { get; set; }
}