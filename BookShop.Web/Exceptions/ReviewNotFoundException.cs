namespace BookShop.Web.Exceptions;

public class ReviewNotFoundException: Exception
{
    public ReviewNotFoundException(Guid id) : base($"Review not found with id:{id}")
    {

    }
}