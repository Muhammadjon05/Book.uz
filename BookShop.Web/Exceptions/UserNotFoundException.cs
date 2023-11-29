namespace BookShop.Web.Exceptions;

public class UserNotFoundException  : Exception
{
    
    public UserNotFoundException(string message): base($"User not found with this: {message}")
    {
        
    }
}