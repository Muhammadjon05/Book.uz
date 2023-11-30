using BookShop.Domain.DtoModels;
using BookShop.Domain.Entities;
using BookShop.Service.Filter;
using BookShop.ViewModel.Models;

namespace BookShop.Service.Repositories.UserRepositories;

public interface IAuthorRepository
{
    ValueTask<AuthorModel> AddAuthor(AuthorDto author);
    ValueTask<ICollection<BookModel>> GetBooksByAuthorId(Guid id);
    
    ValueTask<AuthorModel> GetAuthorById(Guid id);
    ValueTask<IEnumerable<AuthorModel>> GetAllAuthors(AuthorFilter filter);
    void DeleteAuthor(Guid id);
    
}