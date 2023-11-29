namespace BookShop.Domain.DtoModels;

public class LoginDto
{
    public required string UserName { get; set; }
    public required string Password { get; set; }
}