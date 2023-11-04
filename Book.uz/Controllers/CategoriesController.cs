using Book.uz.DtoModels;
using Book.uz.Entities;
using Book.uz.Exceptions;
using Book.uz.Manager.CategoryManager;
using Book.uz.Repositories.CategoryRepository;
using Microsoft.AspNetCore.Mvc;

namespace Book.uz.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private CategoryManager _categoryManager;

    public CategoriesController(CategoryManager categoryManager)
    {
        _categoryManager = categoryManager;
    }

    [HttpPost]
    public  async Task<IActionResult> AddCategoryAsync(CategoryDto dto)
    {
        var category = await _categoryManager.AddCategoryAsync(dto: dto);
        return Ok(category);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryByIdAsync(Guid id)
    {
        try
        {
            var category = await _categoryManager.GetByCategoryAsync(id);
            return Ok(category);
        }
        catch (CategoryNotFoundException e)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategoryAsync(Guid id)
    {
        try
        {
            await _categoryManager.DeleteCategoryAsync(id);
            return Ok("Deleted successfully");
        }
        catch (CategoryNotFoundException e)
        {
            return NotFound();
        }
    }
    [HttpGet]
    public  async Task<IActionResult> GetAllCategoriesAsync()
    {
        var categories = await _categoryManager.GetAllCategoriesAsync();
        return Ok(categories);
    }
}