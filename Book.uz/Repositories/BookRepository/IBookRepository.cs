using Book.uz.DtoModels;
using Book.uz.Filter;
using Book.uz.Models;

namespace Book.uz.Repositories.BookRepository;

public interface IBookRepository
{ 
    ValueTask<BookModel> InsertAsync(BookDto dto);
    ValueTask<IEnumerable<BookModel>> GetAllAsync(BookFilter filter);
    ValueTask<BookModel> GetBookByIdAsync(Guid id);
    void DeleteBook(Guid id);

}