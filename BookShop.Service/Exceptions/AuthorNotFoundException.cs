namespace BookShop.Service.Exceptions;

public class AuthorNotFoundException : Exception
{
    public AuthorNotFoundException(Guid id) : base($"Author not Found with id : {id.ToString()}")
    {
    }
}