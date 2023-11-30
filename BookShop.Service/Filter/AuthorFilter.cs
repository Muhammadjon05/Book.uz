using BookShop.Service.PaginationModels;

namespace BookShop.Service.Filter;

public class AuthorFilter : PaginationParams
{ 
    public string? FullName { get; set; }

}