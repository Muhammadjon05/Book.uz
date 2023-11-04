using Book.uz.DtoModels;
using Book.uz.Exceptions;
using Book.uz.Filter;
using Book.uz.Manager.BookManager;
using Microsoft.AspNetCore.Mvc;

namespace Book.uz.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly BookManager _bookManager;

    public BooksController(BookManager bookManager)
    {
        _bookManager = bookManager;
    }

    [HttpPost]
    public async Task<IActionResult> AddBook([FromBody]BookDto dto)
    {
        var book = await _bookManager.AddBook(dto);
        return  Ok(book);
    }
    [HttpGet]
    public async Task<IActionResult> GetBooks([FromQuery] BookFilter filter)
    {
       
        var book = await _bookManager.GetAllBooks(filter: filter);
        return  Ok(book);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookById(Guid id)
    {
        try
        {
            var book = await _bookManager.GetBookById(id);
            return Ok(book);

        }
        catch (BookNotFoundException e)
        {
            return NotFound();
        }
    } 
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            await _bookManager.GetBookById(id);
            return Ok("Deleted successfully");

        }
        catch (BookNotFoundException e)
        {
            return NotFound();
        }
    }
}