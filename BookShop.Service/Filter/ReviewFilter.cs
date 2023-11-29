using BookShop.Service.PaginationModels;

namespace BookShop.Service.Filter;

public class ReviewFilter : PaginationParams
{
    public string? ReviewText { get; set; }
    public DateTime? WrittenDate { get; set; }
    
}