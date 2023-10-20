namespace Book.uz.Entities;

public class Category
{
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; }  
    public virtual ICollection<Book> Books { get; set; }
}