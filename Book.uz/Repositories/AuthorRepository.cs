using Book.uz.DbContext;
using Book.uz.Entities;
using Book.uz.Repositories.UserRepositories;

namespace Book.uz.Repositories;

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