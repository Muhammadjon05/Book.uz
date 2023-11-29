using AutoMapper;
using BookShop.Web.DbContext;
using BookShop.Web.Entities;
using BookShop.Web.Extensions;
using BookShop.Web.DtoModels;
using BookShop.Web.Exceptions;
using BookShop.Web.Filter;
using BookShop.Web.Models;
using BookShop.Web.PaginationModels;
using BookShop.Web.Repositories.Generic;
using Nest;

namespace BookShop.Web.Repositories.BookRepository;

public class BookRepository : IBookRepository
{
    
    private readonly IElasticClient _client;
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Entities.Book> _bookRepository;
    private readonly HttpContextHelper _httpContext;

    public BookRepository(
        IGenericRepository<Entities.Book> genericRepository,
        HttpContextHelper httpContext, IMapper mapper, IElasticClient client)
    {
        _bookRepository = genericRepository;
        _httpContext = httpContext;
        _mapper = mapper;
        _client = client;
    }


    public async ValueTask<BookModel> InsertAsync(BookDto dto)
    {
        var createBook = _mapper.Map<Entities.Book>(dto);
        var newBook = await _bookRepository.InsertAsync(createBook);
        return _mapper.Map<BookModel>(newBook);
    }

    public async ValueTask<IEnumerable<BookModel>> GetAllAsync(BookFilter filter)
    {
        var books = _bookRepository.SelectAll();
        if (filter.Name is not null)
        {
            books= books.Where(t => t.BookName.ToLower()
                .Contains(filter.Name.ToLower()));
        }  if (filter.Price is not null)
        {
            books = books.Where(t=>t.Price > filter.Price);
        } 
        if (filter.PageSize is not null)
        {
            books = books.Where(t=>t.PageSize > filter.PageSize);
        }
        var booksPages = books.ToPagedListAsync(_httpContext, filter).Result;
        return  booksPages.Select(v=>_mapper.Map<BookModel>(v));
    }

    public async ValueTask<BookModel> GetBookByIdAsync(Guid id)
    {
        var book = _bookRepository.SelectFirstAsync
            (t => t.BookId == id).Result;
        if (book == null)
            throw new BookNotFoundException(id);
        
        return _mapper.Map<BookModel>(book);
    }
    public void DeleteBook(Guid id)
    { 
        var book = _bookRepository.SelectFirstAsync
            (t => t.BookId == id).Result;
        if (book == null)
            throw new BookNotFoundException(id);
        _bookRepository.DeleteAsync(book);
    }
}