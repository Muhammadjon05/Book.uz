using Book.uz.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book.uz.EntityConfiguration;

public class UserOrderConfiguration : IEntityTypeConfiguration<UserOrder>
{
    public void Configure(EntityTypeBuilder<UserOrder> builder)
    {
        builder.HasKey(c => c.Id);
        
        builder
            .HasOne<User>(sc => sc.User)
            .WithMany(s => s.UsersOrders)
            .HasForeignKey(sc => sc.UserId);
        builder
            .HasOne<Order>(sc => sc.Order)
            .WithMany(s => s.UsersOrders)
            .HasForeignKey(sc => sc.OrderId);
    }
}