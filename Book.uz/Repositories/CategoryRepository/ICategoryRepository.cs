using Book.uz.Entities;

namespace Book.uz.Repositories.CategoryRepository;

public interface ICategoryRepository
{
    Task<Category> AddCategory(Category category);
    Task DeleteCategory(Category category);

}