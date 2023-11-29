using BookShop.Domain.Entities;

namespace BookShop.Service.Repositories.UserRepositories;

public interface IAuthorRepository
{
    Task<Author> AddAuthor(Author author);
}