namespace BookShop.Domain.DtoModels;

public class ReviewDto
{
    public Guid BookId { get; set;}
    public string ReviewText { get; set; }
}