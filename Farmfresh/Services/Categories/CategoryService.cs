using Farmfresh.Models;
using Farmfresh.Repositories.Categories;

namespace Farmfresh.Services.Categories;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Category> AddCategory(Category category)
    {
        var result = await _categoryRepository.AddCategory(category);
        return result;
    }

    public async Task<bool> DeleteCategory(int categoryId)
    {
        var deleted = await _categoryRepository.DeleteCategory(categoryId);
        return deleted;
    }

    public async Task<IEnumerable<Category>> GetAll()
    {
        var result = await _categoryRepository.GetAll();
        return result;
    }

    public async Task<Category> GetById(int categoryId)
    {
        var result = await _categoryRepository.GetById(categoryId);
        return result;
    }

    public async Task<Category> UpdateCategory(int categoryId, Category category)
    {
        var entity = await _categoryRepository.UpdateCategory(categoryId, category);
        return entity;
    }
}