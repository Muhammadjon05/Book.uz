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

    public async Task<ICollection<BookModel>> GetAllBooks()
    {
        var books = await _bookRepository.GetAllTheBooks();
        var maps = _mapper.Map<List<BookModel>>(books);
        return maps;
    }

    public Task DeleteBook(Entities.Book book)
    {
        throw new NotImplementedException();
    }

    public async Task<BookModel> GetBookById(Guid bookId)
    {
        var book = await _bookRepository.GetBookById(bookId);
        var bookModel = _mapper.Map<BookModel>(book);
        return bookModel;
    }
}