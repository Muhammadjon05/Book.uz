using BookShop.Domain.DtoModels;
using BookShop.Service.Filter;
using BookShop.ViewModel.Models;

namespace BookShop.Service.Repositories.BookRepository;

public interface IBookRepository
{ 
    ValueTask<BookModel> InsertAsync(BookDto dto);
    ValueTask<IEnumerable<BookModel>> GetAllAsync(BookFilter filter);
    ValueTask<BookModel> GetBookByIdAsync(Guid id);
    void DeleteBook(Guid id);

}