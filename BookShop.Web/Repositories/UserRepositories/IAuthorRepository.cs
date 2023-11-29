using BookShop.Web.Entities;

namespace BookShop.Web.Repositories.UserRepositories;

public interface IAuthorRepository
{
    Task<Author> AddAuthor(Author author);
}