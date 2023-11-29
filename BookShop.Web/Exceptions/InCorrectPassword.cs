namespace BookShop.Web.Exceptions;

public class InCorrectPassword : Exception
{
    public InCorrectPassword(string password): base($"Given password:{password} is incorrect")
    {
        
    }
}