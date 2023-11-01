namespace Book.uz.Repositories.BookRepository;

public interface IBookRepository
{
    Task<ICollection<uz.Entities.Book>> GetAllTheBooks();
    Task<Entities.Book> AddBook(Entities.Book book);
    Task DeleteBook(Entities.Book book);
    Task<Entities.Book> GetBookById(Guid bookId);

}