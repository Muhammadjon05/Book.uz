using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    public Category Category { get; set; }
    public ICollection<BookAuthor> BooksAuthors {get;set;}
}