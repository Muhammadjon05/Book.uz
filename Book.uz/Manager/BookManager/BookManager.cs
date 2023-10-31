using AutoMapper;
using Book.uz.DbContext;
using Book.uz.DtoModels;
using Book.uz.Entities;
using Book.uz.Models;
using Book.uz.Repositories.BookRepository;
using Book.uz.Repositories.UserRepositories;


namespace Book.uz.Manager.BookManager;

public class BookManager
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;
    public BookManager(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }
    public async Task<BookModel> AddBook(BookDto dto)
    {
        var book = _mapper.Map<Entities.Book>(dto);
        book.Authors = _mapper.Map<List<Author>>(dto.AuthoInfo);
        book =  await _bookRepository.AddBook(book);
         return _mapper.Map<BookModel>(book);
    }

    public Task DeleteBook(Entities.Book book)
    {
        throw new NotImplementedException();
    }

    public Task<Entities.Book> GetBookById(Guid bookId)
    {
        throw new NotImplementedException();
    }
}