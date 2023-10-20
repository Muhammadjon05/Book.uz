namespace Book.uz.Entities;

public class User
{
    public Guid UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public required string Password { get; set; }
    public string PasswordHash { get; set; } = null!;
    public virtual ICollection<UserOrder> UsersOrders { get; set; }
    public virtual ICollection<Review> Reviews { get; set; }
}
