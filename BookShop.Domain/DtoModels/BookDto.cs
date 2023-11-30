using BookShop.Domain.Enums;

namespace BookShop.Domain.DtoModels;

public class BookDto
{
    public string BookName { get; set; }
    public Language Language { get; set; } 
    public int PageSize { get; set;}
    public decimal Price { get; set; }
    public ContentLanguage ContentLanguage { get; set; }
    public int Year { get; set; }
    public string? Description { get; set; }
    public BookCover BookCover { get; set; }
    public bool IsAvailable { get; set; }
    public bool? HasDiscount { get; set; }
    public decimal? Discount { get; set; }
    public string PaperFormat { get; set; }
    public Guid CategoryId { get; set; }
    public Guid AuthorId{get;set;}
}