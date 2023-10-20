namespace Book.uz.Exceptions;

public class UserNotFoundException  : Exception
{
    
    public UserNotFoundException(string message): base($"User not found with this: {message}")
    {
        
    }
}