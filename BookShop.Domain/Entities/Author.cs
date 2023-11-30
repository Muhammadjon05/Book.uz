namespace BookShop.Domain.Entities;

public class Author
{
    public Guid AuthorId { get; set; }
    public string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime? DateOfDeath { get; set; }
    public virtual ICollection<Book> Books {get;set;}
}
