namespace BookShop.ViewModel.Models;

public class CategoryModel
{
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; } 
    public ICollection<BookModel> Books { get; set; }
}