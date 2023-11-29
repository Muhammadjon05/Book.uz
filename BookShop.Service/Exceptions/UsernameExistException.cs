namespace BookShop.Web.Exceptions;

public class UsernameExistException : Exception
{
    public UsernameExistException(string username) : base($"With this username:{username} user is exist")
    {
        
    }
    
}