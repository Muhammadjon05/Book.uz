using Book.uz.DtoModels;
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
}