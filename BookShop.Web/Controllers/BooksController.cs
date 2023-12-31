﻿using BookShop.Domain.DtoModels;
using BookShop.Service.Filter;
using BookShop.Service.Repositories.BookRepository;
using BookShop.Web.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookRepository _bookRepository;

    public BooksController(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }


    [HttpPost]
    public async Task<IActionResult> AddBook([FromForm]BookDto dto)
    {
        var book = await _bookRepository.InsertAsync(dto);
        return  Ok(book);
    }
    [HttpGet]
    public async Task<IActionResult> GetBooks([FromQuery] BookFilter filter)
    {
        var book = await _bookRepository.GetAllAsync(filter: filter);
        return  Ok(book);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookById(Guid id)
    {
        try
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
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
             _bookRepository.DeleteBook(id);
             return Ok("Deleted");
        }
        catch (BookNotFoundException e)
        {
            return NotFound();
        }
    }
}