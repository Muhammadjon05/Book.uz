using System.ComponentModel.DataAnnotations.Schema;

namespace Book.uz.Entities;

public class BookAuthor
{
    public Guid Id { get; set; }
    public Guid BookId { get; set; }
    public Book Book { get; set; }
    public Guid AuthorId { get; set; }
    public Author Author { get; set; }
}