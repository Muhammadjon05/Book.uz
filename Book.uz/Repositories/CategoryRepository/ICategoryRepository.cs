using Book.uz.Entities;

namespace Book.uz.Repositories.CategoryRepository;

public interface ICategoryRepository
{
    Task<Category> AddCategoryAsync(Category category);
    Task<ICollection<Category>> GetAllCategoriesAsync();
    Task<Category?> GetCategoryByIdAsync(Guid id);
    Task DeleteCategoryAsync(Category category);

}