namespace Book.uz.DtoModels;

public class ReviewDto
{
    public Guid BookId { get; set;}
    public Guid UserId { get; set; }
    public string ReviewText { get; set; }
    public DateTime ReviewedDate { get; set; }
}