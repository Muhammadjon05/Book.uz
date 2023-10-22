using Book.uz.Entities;
using Book.uz.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Book.uz.DbContext;

public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {
        
    }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Entities.Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<User> Users { get; set; }
    //public DbSet<BookAuthor> BookAuthors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BooksConfiguration());
        modelBuilder.ApplyConfiguration(new ReviewConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
    }
}