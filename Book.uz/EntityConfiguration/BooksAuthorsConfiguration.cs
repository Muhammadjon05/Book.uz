using Book.uz.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book.uz.EntityConfiguration;

public class BooksAuthorsConfiguration : IEntityTypeConfiguration<BookAuthor>
{
    public void Configure(EntityTypeBuilder<BookAuthor> builder)
    {
        builder.HasKey(c=>c.Id);
        builder
            .HasOne<Entities.Book>(sc => sc.Book)
            .WithMany(s => s.BooksAuthors)
            .HasForeignKey(sc => sc.BookId);
        
        builder
            .HasOne<Author>(sc => sc.Author)
            .WithMany(s => s.BooksAuthors)
            .HasForeignKey(sc => sc.AuthorId);
        
    }
}