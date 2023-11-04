using Book.uz.DbContext;
using Book.uz.Entities;
using Microsoft.EntityFrameworkCore;

namespace Book.uz.Repositories.BookRepository;

public class BookRepository : IBookRepository
{
    private readonly AppDbContext _appDbContext;
    

    public BookRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Entities.Book> AddBook(Entities.Book book)
    {
        await _appDbContext.Books.AddAsync(book);
        await _appDbContext.SaveChangesAsync();
        return book;
    }

    public async Task DeleteBook(Entities.Book book)
    {
        _appDbContext.Books.Remove(book);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<Entities.Book> GetBookById(Guid bookId)
    {
        var book =  await _appDbContext.Books.Where
            (i=>i.BookId == bookId).Include(i=>i.Authors).
            Include(i=>i.Reviews)
            .FirstOrDefaultAsync();
        return book;
    }

    public async ValueTask<IQueryable<Entities.Book>> GetAllTheBooks()
    {
        var books =  _appDbContext.Books.
            Include(i => i.Authors).Include(i=>i.Reviews).AsQueryable();
        return books;
    }

    
}