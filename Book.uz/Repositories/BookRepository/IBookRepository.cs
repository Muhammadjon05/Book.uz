namespace Book.uz.Repositories.BookRepository;

public interface IBookRepository
{ 
    ValueTask<IQueryable<Entities.Book>>GetAllTheBooks();
    Task<Entities.Book> AddBook(Entities.Book book);
    Task DeleteBook(Entities.Book book);
    Task<Entities.Book> GetBookById(Guid bookId);

}