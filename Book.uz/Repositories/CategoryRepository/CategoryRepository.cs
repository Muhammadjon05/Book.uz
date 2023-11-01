using Book.uz.DbContext;
using Book.uz.Entities;

namespace Book.uz.Repositories.CategoryRepository;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _appDbContext;

    public CategoryRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public  async Task<Category> AddCategory(Category category)
    {
        await _appDbContext.Categories.AddAsync(category);
        await _appDbContext.SaveChangesAsync();
        return category;
    }

    public async Task DeleteCategory(Category category)
    {
        _appDbContext.Categories.Remove(category);
        await _appDbContext.SaveChangesAsync();
    }
}