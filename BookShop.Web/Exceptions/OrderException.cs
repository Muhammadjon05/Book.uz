namespace BookShop.Web.Exceptions;

public class OrderException : Exception
{
    public OrderException(Guid id) : base($"Order not found with id:{id}")
    {

    }
}
