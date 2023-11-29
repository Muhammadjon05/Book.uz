namespace BookShop.ViewModel.Models;

public class ReviewModel
{
    public Guid ReviewId { get; set; }
    public Guid BookId { get; set;}
    public Guid UserId { get; set; }
    public string ReviewText { get; set; }
    public DateTime ReviewedDate { get; set; }
}