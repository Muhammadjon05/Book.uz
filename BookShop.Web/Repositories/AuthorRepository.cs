using BookShop.Web.DbContext;
using BookShop.Web.Entities;
using BookShop.Web.Repositories.UserRepositories;

namespace BookShop.Web.Repositories;

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