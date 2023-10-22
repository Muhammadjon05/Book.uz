using Book.uz.Entities;
using Book.uz.Enums;

namespace Book.uz.Models;

public class BookModel
{
    public Guid BookId { get; set; }
    public string BookName { get; set; }
    public Language Language { get; set; } 
    public int PageSize { get; set;}
    public decimal Price { get; set; }
    public string PhotoUrl { get; set; }
    public Guid CategoryId { get; set; }
    public  ICollection<AuthorModel> Authors {get;set;}
    public  ICollection<ReviewModel> Reviews { get; set; }
}