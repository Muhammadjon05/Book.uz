
using Book.uz.Enums;

namespace Book.uz.Entities;

public class Book
{
    public Guid BookId { get; set; }
    public string BookName { get; set; }
    public Language Language { get; set; } 
    public int PageSize { get; set;}
    public decimal Price { get; set; }
    public string PhotoUrl { get; set; }
    public Guid CategoryId { get; set; }
    public virtual Category Category { get; set; }
    public virtual ICollection<Author> Auhtors {get;set;}
    public virtual ICollection<Review> Reviews { get; set; }
    
}