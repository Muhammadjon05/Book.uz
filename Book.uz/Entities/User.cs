namespace Book.uz.Entities;

public class User
{
    public Guid UserId { get; set; }
    public string FirstName { get; set; }
    public string Username { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public  string Password { get; set; }
    public string PasswordHash { get; set; } = null!;
    public virtual ICollection<Order>? Orders { get; set; }
    public virtual ICollection<Review>? Reviews { get; set; }
}
