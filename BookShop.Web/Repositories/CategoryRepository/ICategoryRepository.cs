using BookShop.Web.Entities;
using BookShop.Web.DtoModels;
using BookShop.Web.Filter;
using BookShop.Web.Models;

namespace BookShop.Web.Repositories.CategoryRepository;

public interface ICategoryRepository
{
    ValueTask<CategoryModel> InsertAsync(CategoryDto dto);
    ValueTask<IEnumerable<CategoryModel>> GetAllAsync(CategoryFilter filter);
    ValueTask<CategoryModel> GetByCategoryIdAsync(Guid id);
    void DeleteCategory(Guid id);

}