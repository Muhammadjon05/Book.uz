﻿using AutoMapper;
using Book.uz.DbContext;
using Book.uz.DtoModels;
using Book.uz.Entities;
using Book.uz.Exceptions;
using Book.uz.Extensions;
using Book.uz.Filter;
using Book.uz.Models;
using Book.uz.PaginationModels;
using Book.uz.Repositories.Generic;
using Nest;

namespace Book.uz.Repositories.BookRepository;

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
        /*var books = _bookRepository.SelectAll();*/
        
        var result =  _client.SearchAsync
            <Entities.Book>(s
            => s.Query(q => q
                .QueryString(d =>
                    d.Query('*'+filter.Name+'*'))).Size(1000)).Result.Documents.AsQueryable();
        
        /*if (filter.Name is not null)
        {
            result = books.Where(t => t.BookName.ToLower()
                .Contains(filter.Name.ToLower()));
        }  if (filter.Price is not null)
        {
            books = books.Where(t=>t.Price > filter.Price);
        } 
        if (filter.PageSize is not null)
        {
            books = books.Where(t=>t.PageSize > filter.PageSize);
        }*/
        
        var booksPages =  result.
            ToPagedListAsync(_httpContext, filter).Result.ToList();
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