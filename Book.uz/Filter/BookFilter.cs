using Book.uz.PaginationModels;

namespace Book.uz.Filter;

public class BookFilter : PaginationParams
{
    public string? Name { get; set; }
    public int?  PageSize { get; set; }
    public decimal? Price { get; set; }
}