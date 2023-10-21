using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book.uz.EntityConfiguration;

public class BookConfiguration : IEntityTypeConfiguration<Entities.Book>
{
    public void Configure(EntityTypeBuilder<Entities.Book> builder)
    {
        builder.HasMany(c => c.Auhtors)
            .WithMany(c => c.Books)
            .UsingEntity(m => m.ToTable("BookAuthor")
                .Property<Guid>("Id"));
    }
}