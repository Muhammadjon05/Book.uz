using Book.uz.Entities;

namespace Book.uz.Repositories.CategoryRepository;

public interface ICategoryRepository
{
    Task<Category> AddCategory(Category category);
    Task<ICollection<Category>> GetAllCategories();
    Task<Category?> GetCategoryById(Guid id);
    Task DeleteCategory(Category category);

}