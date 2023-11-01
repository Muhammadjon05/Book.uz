using AutoMapper;
using Book.uz.DtoModels;
using Book.uz.Entities;
using Book.uz.Models;
using Book.uz.Repositories.CategoryRepository;

namespace Book.uz.Manager.CategoryManager;

public class CategoryManager
{
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;

    public CategoryManager(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<CategoryModel> AddCategory(CategoryDto dto)
    {
        var categoryD = _mapper.Map<Category>(dto); 
        var category = await _categoryRepository.AddCategory(categoryD);
        return _mapper.Map<CategoryModel>(category);
    }

    public async Task DeleteCategory(Guid id)
    {
        
    }
}