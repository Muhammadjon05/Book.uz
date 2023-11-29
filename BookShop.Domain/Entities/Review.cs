namespace BookShop.Domain.Entities;

public class Review
{
    public Guid ReviewId { get; set; }
    
    public Guid BookId { get; set;}
    public virtual Book Book { get; set; }
    
    public Guid UserId { get; set; }
    public virtual User User { get; set; }
    
    public string ReviewText { get; set; }
    public DateTime ReviewedDate { get; set; }
    
}
