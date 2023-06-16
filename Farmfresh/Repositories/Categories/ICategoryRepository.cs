using Farmfresh.Models;

namespace Farmfresh.Repositories.Categories;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAll();
    Task<Category> GetById(int categoryId);
    Task<Category> AddCategory(Category category);
    Task<Category> UpdateCategory(int categoryId, Category category);
    Task<bool> DeleteCategory(int categoryId);
}