using BookShop.Data.DbContext;
using BookShop.Domain.Entities;
using BookShop.Service.Repositories.UserRepositories;

namespace BookShop.Service.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly AppDbContext _appDbContext;

    public AuthorRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Author> AddAuthor(Author author)
    {
        await _appDbContext.Authors.AddAsync(author);
        await _appDbContext.SaveChangesAsync();
        return author;
    }
}