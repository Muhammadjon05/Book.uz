using BookShop.Web.DtoModels;
using BookShop.Web.Filter;
using BookShop.Web.Models;

namespace BookShop.Web.Repositories.BookRepository;

public interface IBookRepository
{ 
    ValueTask<BookModel> InsertAsync(BookDto dto);
    ValueTask<IEnumerable<BookModel>> GetAllAsync(BookFilter filter);
    ValueTask<BookModel> GetBookByIdAsync(Guid id);
    void DeleteBook(Guid id);

}