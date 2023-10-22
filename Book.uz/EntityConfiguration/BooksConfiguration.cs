﻿using Book.uz.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book.uz.EntityConfiguration;

public class BooksConfiguration : IEntityTypeConfiguration<Entities.Book>
{
    public void Configure(EntityTypeBuilder<Entities.Book> builder)
    {

        builder.HasKey(c => c.BookId); 
        builder.HasMany(c => c.Authors).WithMany(c => c.Books);

        /*
        builder.HasKey(i => i.Id);

       builder
            .HasOne(ba => ba.Book)
            .WithMany(b => b.BooksAuthors)
            .HasForeignKey(ba => ba.BookId);
      builder
           .HasOne(ba => ba.Author)
           .WithMany(a => a.AuthorsBooks)
           .HasForeignKey(ba => ba.AuthorId);*/
    }
}