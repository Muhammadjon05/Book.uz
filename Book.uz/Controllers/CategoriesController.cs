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
    public  async Task<IActionResult> AddCategory(CategoryDto dto)
    {
        var category = await _categoryManager.AddCategory(dto: dto);
        return Ok(category);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById(Guid id)
    {
        try
        {
            var category = await _categoryManager.GetByCategory(id);
            return Ok(category);
        }
        catch (CategoryNotFoundException e)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(Guid id)
    {
        try
        {
            await _categoryManager.DeleteCategory(id);
            return Ok("Deleted successfully");
        }
        catch (CategoryNotFoundException e)
        {
            return NotFound();
        }
    }
    [HttpGet]
    public  async Task<IActionResult> GetAllCategories()
    {
        var categories = await _categoryManager.GetAllCategories();
        return Ok(categories);
    }
}