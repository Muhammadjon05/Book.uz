using Book.uz.DtoModels;
using Book.uz.Entities;
using Book.uz.Filter;
using Book.uz.Models;

namespace Book.uz.Repositories.CategoryRepository;

public interface ICategoryRepository
{
    ValueTask<CategoryModel> InsertAsync(CategoryDto dto);
    ValueTask<IEnumerable<CategoryModel>> GetAllAsync(CategoryFilter filter);
    ValueTask<CategoryModel> GetByCategoryIdAsync(Guid id);
    void DeleteCategory(Guid id);

}