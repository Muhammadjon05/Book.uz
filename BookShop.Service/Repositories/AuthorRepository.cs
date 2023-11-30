using AutoMapper;
using BookShop.Domain.DtoModels;
using BookShop.Domain.Entities;
using BookShop.Service.Exceptions;
using BookShop.Service.Extensions;
using BookShop.Service.Filter;
using BookShop.Service.PaginationModels;
using BookShop.Service.Repositories.Generic;
using BookShop.Service.Repositories.UserRepositories;
using BookShop.ViewModel.Models;

namespace BookShop.Service.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Author> _authorRepository;
    private readonly HttpContextHelper _httpContext;
    
    

    public AuthorRepository(IMapper mapper, IGenericRepository<Author> genericRepository, HttpContextHelper httpContext)
    {
        _mapper = mapper;
        _authorRepository = genericRepository;
        _httpContext = httpContext;
    }

    public ValueTask<AuthorModel> AddAuthor(AuthorDto dto)
    {
        var author = _mapper.Map<Author>(dto);
        var newAuthor =_authorRepository.InsertAsync(author).Result;
        return new ValueTask<AuthorModel>(_mapper.Map<AuthorModel>(newAuthor));
    }

    public ValueTask<ICollection<BookModel>> GetBooksByAuthorId(Guid id)
    {
        var author =_authorRepository.SelectFirstAsync(t=>t.AuthorId == id).Result!;

        if (author is null)
        {
            throw new AuthorNotFoundException(id);
        }
        
        if (author.Books is null)
        {
            return new ValueTask<ICollection<BookModel>>();
        }
        else
        {
            var books = _mapper.Map<ICollection<BookModel>>(author.Books);
            return new ValueTask<ICollection<BookModel>>(books);
        }
    }

    public ValueTask<AuthorModel> GetAuthorById(Guid id)
    {
        var author = _authorRepository.SelectFirstAsync(t => t.AuthorId == id).Result;
        if (author is null)
        {
            throw new AuthorNotFoundException(id);
        }
        else
        {
            return new ValueTask<AuthorModel>(_mapper.Map<AuthorModel>(author));
        }
    }

    public ValueTask<IEnumerable<AuthorModel>> GetAllAuthors(AuthorFilter filter)
    {
        var authors = _authorRepository.SelectAll();
        if (filter.FullName != null)
        {
            authors = authors.Where(t => t.FullName.ToLower()
                .Contains(filter.FullName.ToLower()));
        }
        var authorPages = authors.ToPagedListAsync(_httpContext, filter).Result;
        return new ValueTask<IEnumerable<AuthorModel>>(authorPages.Select(v => _mapper.Map<AuthorModel>(v)));
    }

    public void DeleteAuthor(Guid id)
    {
        var author = _authorRepository.SelectFirstAsync(t => t.AuthorId == id).Result;
        if (author is null)
        {
            throw new AuthorNotFoundException(id);
        }
        else
        {
            _authorRepository.DeleteAsync(author);
        }
    }
}