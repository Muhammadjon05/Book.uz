namespace BookShop.ViewModel.Models;

public class AuthorModel
{ 
    public Guid AuthorId { get; set; }
    public string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime? DateOfDeath { get; set; }
    public virtual ICollection<BookModel> Books {get;set;}
}