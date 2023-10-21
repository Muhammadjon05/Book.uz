namespace Book.uz.Entities;

public class Author
{
    public Guid AuthorId { get; set; }
    public string AuthorName { get; set; }
    public string AuthorLastName { get; set; }
    public string AuthorEmail { get; set; }
    public virtual ICollection<Book> Books {get;set;}
}
