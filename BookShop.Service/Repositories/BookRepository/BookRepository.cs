using AutoMapper;
using BookShop.Domain.DtoModels;
using BookShop.Domain.Entities;
using BookShop.Service.Extensions;
using BookShop.Service.Filter;
using BookShop.Service.PaginationModels;
using BookShop.Service.Repositories.Generic;
using BookShop.ViewModel.Models;
using BookShop.Web.Exceptions;

namespace BookShop.Service.Repositories.BookRepository;

public class BookRepository : IBookRepository
{
    
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Book> _bookRepository;
    private readonly HttpContextHelper _httpContext;

    public BookRepository(
        IGenericRepository<Book> genericRepository,
        HttpContextHelper httpContext, IMapper mapper)
    {
        _bookRepository = genericRepository;
        _httpContext = httpContext;
        _mapper = mapper;
    }


    public async ValueTask<BookModel> InsertAsync(BookDto dto)
    {
        var createBook = _mapper.Map<Book>(dto);
        createBook.Authors = _mapper.Map<ICollection<Author>>(dto.AuthoInfo);
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