using System.ComponentModel.DataAnnotations.Schema;

namespace Book.uz.Entities;

public class UserOrder
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Guid OrderId { get; set; }
    public Order Order { get; set; }
}