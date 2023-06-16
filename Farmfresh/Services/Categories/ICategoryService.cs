using Farmfresh.Models;

namespace Farmfresh.Services.Categories;

public interface ICategoryService
{
    Task<IEnumerable<Category>> GetAll();
    Task<Category> GetById(int categoryId);
    Task<Category> AddCategory(Category category);
    Task<Category> UpdateCategory(int categoryId, Category category);
    Task<bool> DeleteCategory(int categoryId);
}