using BookShop.Web.Entities;
using BookShop.Web.DtoModels;
using BookShop.Web.Exceptions;
using BookShop.Web.Filter;
using BookShop.Web.Repositories.CategoryRepository;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private ICategoryRepository _categoryRepository;

    public CategoriesController(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }


    [HttpPost]
    public  async Task<IActionResult> AddCategoryAsync(CategoryDto dto)
    {
        var category = await _categoryRepository.InsertAsync(dto: dto);
        return Ok(category);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryByIdAsync(Guid id)
    {
        try
        {
            var category = await _categoryRepository.GetByCategoryIdAsync(id);
            return Ok(category);
        }
        catch (CategoryNotFoundException e)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public Task<IActionResult> DeleteCategoryAsync(Guid id)
    {
        try
        {
             _categoryRepository.DeleteCategory(id);
            return Task.FromResult<IActionResult>(Ok("Deleted successfully"));
        }
        catch (CategoryNotFoundException e)
        {
            return Task.FromResult<IActionResult>(NotFound());
        }
    }
    [HttpGet]
    public  async Task<IActionResult> GetAllCategoriesAsync([FromQuery] CategoryFilter filter)
    {
        var categories = await _categoryRepository.GetAllAsync(filter);
        return Ok(categories);
    }
}