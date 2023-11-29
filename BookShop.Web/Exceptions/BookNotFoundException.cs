namespace BookShop.Web.Exceptions;

public class BookNotFoundException : Exception
{
    public BookNotFoundException(Guid id): base($"Book not found with id:{id}")
    {
         
    }
}