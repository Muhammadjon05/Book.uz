using Book.uz.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book.uz.EntityConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasMany(c => c.Orders)
            .WithOne(c => c.User).
            HasForeignKey(c => c.UserId);
    }
}