namespace BookShop.Web.Models;

public class UserModel
{
    public Guid UserId { get; set; }
    public required string Firstname { get; set; }
    public string? Lastname { get; set; }
    public required string Username { get; set; }
    public virtual List<UserModel>? UserOrderModels { get; set; }
}