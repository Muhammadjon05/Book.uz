using BookShop.Domain.Enums;

namespace BookShop.Domain.Entities;

public class Book
{
    public Guid BookId { get; set; }
    public string BookName { get; set; }
    public Language Language { get; set; } 
    public int PageSize { get; set;}
    public decimal Price { get; set; }
    public ContentLanguage ContentLanguage { get; set; }
    public string? ImageUrl { get; set; }
    public int Year { get; set; }
    public string? Description { get; set; }
    public BookCover BookCover { get; set; }
    public bool IsAvailable { get; set; }
    public bool? HasDiscount { get; set; }
    public decimal? Discount { get; set; }
    public string? PaperFormat { get; set; }
    public Guid CategoryId { get; set; }
    public virtual Category Category { get; set; }
    public Guid AuthorId{get;set;}
    public virtual Author Author{get;set;}
    public virtual ICollection<Review> Reviews { get; set; }
    
}