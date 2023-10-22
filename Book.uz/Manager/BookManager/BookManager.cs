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
    private BookModel ToBookModel(Entities.Book book)
    {
        var bookModel = _mapper.Map<BookModel>(book);
       // bookModel.Auhtors = _mapper.Map<List<AuthorModel>>(book.Authors);
        bookModel.Reviews = _mapper.Map<List<ReviewModel>>(book.Reviews);
        return bookModel;
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