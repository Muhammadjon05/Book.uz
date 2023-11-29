using BookShop.Data.EntityConfiguration;
using BookShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Data.DbContext;

public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {
        
    }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BooksConfiguration());
        modelBuilder.ApplyConfiguration(new ReviewConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
    }
}