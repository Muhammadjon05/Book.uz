using AutoMapper;
using Book.uz.DbContext;
using Book.uz.DtoModels;
using Book.uz.Entities;
using Book.uz.Exceptions;
using Book.uz.Extensions;
using Book.uz.Filter;
using Book.uz.Models;
using Book.uz.PaginationModels;
using Book.uz.Repositories.BookRepository;
using Book.uz.Repositories.UserRepositories;
using Microsoft.EntityFrameworkCore;


namespace Book.uz.Manager.BookManager;

public class BookManager
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;
    private readonly HttpContextHelper _httpContext;
    public BookManager(IBookRepository bookRepository, IMapper mapper, HttpContextHelper httpContext)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
        _httpContext = httpContext;
    }
    public async ValueTask<BookModel> AddBook(BookDto dto)
    {
        var book = _mapper.Map<Entities.Book>(dto);
        book.Authors = _mapper.Map<List<Author>>(dto.AuthoInfo);
        book =  await _bookRepository.AddBook(book);
        return _mapper.Map<BookModel>(book);
    }

    public async ValueTask<IEnumerable<BookModel>> GetAllBooks(BookFilter filter)
    {
        var books = _bookRepository.GetAllTheBooks().Result;

        if (filter.Name is not null)
        {
            books = books.Where(t => t.BookName.ToLower().Contains(filter.Name.ToLower()));
        }  if (filter.Price is not null)
        {
            books = books.Where(t=>t.Price > filter.Price);
        } 
        if (filter.PageSize is not null)
        {
            books = books.Where(t=>t.PageSize > filter.PageSize);
        }

        var booksPages = await books.AsNoTracking().ToPagedListAsync(_httpContext, filter);
        return  booksPages.Select(v=>_mapper.Map<BookModel>(v));
    }

    public async ValueTask DeleteBook(Guid id)
    {
        var book = await _bookRepository.GetBookById(id);
        if (book == null)
        {
            throw new BookNotFoundException(id);
        }
        await _bookRepository.DeleteBook(book);
    }

    public async ValueTask<BookModel> GetBookById(Guid bookId)
    {
        var book = await _bookRepository.GetBookById(bookId);
        if (book == null)
        {
            throw new BookNotFoundException(bookId);
        }
        var bookModel = _mapper.Map<BookModel>(book);
        return bookModel;
    }
}