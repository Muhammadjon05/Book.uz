﻿using AutoMapper;
using Book.uz.DbContext;
using Book.uz.DtoModels;
using Book.uz.Entities;
using Book.uz.Exceptions;
using Book.uz.Extensions;
using Book.uz.Filter;
using Book.uz.Models;
using Book.uz.PaginationModels;
using Book.uz.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace Book.uz.Repositories.CategoryRepository;

public class CategoryRepository : ICategoryRepository
{
    private readonly IMapper _mapper;
    private readonly HttpContextHelper _httpContext;
    private IGenericRepository<Category> _categoryRepository;
    public CategoryRepository(IMapper mapper, HttpContextHelper httpContext, IGenericRepository<Category> categoryRepository)
    {
        _mapper = mapper;
        _httpContext = httpContext;
        _categoryRepository = categoryRepository;
    }


    public async ValueTask<CategoryModel> InsertAsync(CategoryDto dto)
    {
        var createCategory = _mapper.Map<Category>(dto);
        var newBook = await _categoryRepository.InsertAsync(createCategory);
        return _mapper.Map<CategoryModel>(newBook);
    }

    public async ValueTask<IEnumerable<CategoryModel>> GetAllAsync(CategoryFilter filter)
    {
        var categories = _categoryRepository.SelectAll();
        if (filter.Name is not null)
        {
            categories = categories.Where(t => t.CategoryName.ToLower()
                .Contains(filter.Name.ToLower()));
        }
        var categoryPages = await categories.
            ToPagedListAsync(_httpContext, filter);
        return  categoryPages.Select(v=>_mapper.Map<CategoryModel>(v));
    }

    public ValueTask<CategoryModel> GetByCategoryIdAsync(Guid id)
    {   var category =  _categoryRepository.SelectFirstAsync
            (t => t.CategoryId == id).Result;
        if (category == null)
            throw new CategoryNotFoundException(id);

        return ValueTask.FromResult(_mapper.Map<CategoryModel>(category));
    }

    public void DeleteCategory(Guid id)
    {  var category = _categoryRepository.SelectFirstAsync
            (t => t.CategoryId == id).Result;
        if (category == null)
            throw new BookNotFoundException(id);
        _categoryRepository.DeleteAsync(category);
    }
}