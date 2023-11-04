﻿using AutoMapper;
using Book.uz.DtoModels;
using Book.uz.Entities;
using Book.uz.Exceptions;
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

    public async Task<CategoryModel> AddCategoryAsync(CategoryDto dto)
    {
        var categoryD = _mapper.Map<Category>(dto); 
        var category = await _categoryRepository.AddCategoryAsync(categoryD);
        return _mapper.Map<CategoryModel>(category);
    }
    public async Task<ICollection<CategoryModel>> GetAllCategoriesAsync()
    {
        var categories = await _categoryRepository.GetAllCategoriesAsync();
        var catModels = _mapper.Map<ICollection<CategoryModel>>(categories);
        return catModels;
    }


    public async Task DeleteCategoryAsync(Guid id)
    {
        var category = await _categoryRepository.GetCategoryByIdAsync(id);
        if (category == null)
        {
            throw new CategoryNotFoundException(id);
        }
        await _categoryRepository.DeleteCategoryAsync(category: category);
    }
    public async Task<CategoryModel> GetByCategoryAsync(Guid id)
    {
        var category = await _categoryRepository.GetCategoryByIdAsync(id);
        if (category == null)
        {
            throw new CategoryNotFoundException(id);
        }
        var categoryModel = _mapper.Map<CategoryModel>(category);
        return categoryModel;
    }
}