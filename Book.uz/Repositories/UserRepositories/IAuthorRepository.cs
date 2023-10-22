using Book.uz.Entities;

namespace Book.uz.Repositories.UserRepositories;

public interface IAuthorRepository
{
    Task<Author> AddAuthor(Author author);
}