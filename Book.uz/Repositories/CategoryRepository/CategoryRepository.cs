﻿using Book.uz.DbContext;
using Book.uz.Entities;
using Microsoft.EntityFrameworkCore;

namespace Book.uz.Repositories.CategoryRepository;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _appDbContext;

    public CategoryRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public  async Task<Category> AddCategoryAsync(Category category)
    {
        await _appDbContext.Categories.AddAsync(category);
        await _appDbContext.SaveChangesAsync();
        return category;
    }

    public async Task<ICollection<Category>> GetAllCategoriesAsync()
    {
        var categories = await _appDbContext.Categories.ToListAsync();
        return categories;
    }

    public async Task<Category?> GetCategoryByIdAsync(Guid id)
    {
        var category = await _appDbContext.Categories.Where(i => i.CategoryId == id).
            Include(i => i.Books).
            ThenInclude(i=>i.Authors).Include(i=>i.Books).ThenInclude(i=>i.Reviews)
            .FirstOrDefaultAsync();
        return category;
    }

    public async Task DeleteCategoryAsync(Category category)
    {
        _appDbContext.Categories.Remove(category);
        await _appDbContext.SaveChangesAsync();
    }
}