using BookShop.Domain.DtoModels;
using BookShop.Service.Exceptions;
using BookShop.Service.Filter;
using BookShop.Service.Repositories.UserRepositories;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Web.Controllers;


[ApiController]
[Route("api/[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly IAuthorRepository _authorRepository;

    public AuthorsController(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }
    [HttpGet]
    public async ValueTask<IActionResult> GetAllAuthors([FromQuery] AuthorFilter filter)
    {
        var authors = await _authorRepository.GetAllAuthors(filter);
        return Ok(authors);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAuthorById(Guid id)
    {
        try
        {
            var author = await _authorRepository.GetAuthorById(id);
            return Ok(author);
        }
        catch (AuthorNotFoundException e)
        {
            return NotFound("Author not found");
        }
    }
    [HttpPost]
    public async ValueTask<IActionResult> AddAuthor([FromBody] AuthorDto dto)
    {
        var author = await _authorRepository.AddAuthor(dto);
        return Ok(author);
    }
    [HttpDelete("{id}")]
    public async ValueTask<IActionResult> Delete(Guid id)
    {
        try
        {
            _authorRepository.DeleteAuthor(id);
            return Ok("Deleted");
        }
        catch (AuthorNotFoundException e)
        {
            return NotFound();
        }
    }
    [HttpGet("{id}/books")]
    public async ValueTask<IActionResult> GetBooksByAuthorId(Guid id)
    {
        try
        { 
            var books = await _authorRepository.GetBooksByAuthorId(id);
            return Ok(books);

        }
        catch (AuthorNotFoundException e)
        {
            return NotFound();
        }
       
    }
    
}