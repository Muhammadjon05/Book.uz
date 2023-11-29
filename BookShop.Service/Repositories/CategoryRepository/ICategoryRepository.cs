using BookShop.Domain.DtoModels;
using BookShop.Service.Filter;
using BookShop.ViewModel.Models;

namespace BookShop.Service.Repositories.CategoryRepository;

public interface ICategoryRepository
{
    ValueTask<CategoryModel> InsertAsync(CategoryDto dto);
    ValueTask<IEnumerable<CategoryModel>> GetAllAsync(CategoryFilter filter);
    ValueTask<CategoryModel> GetByCategoryIdAsync(Guid id);
    void DeleteCategory(Guid id);

}