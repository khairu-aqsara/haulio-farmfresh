using AutoMapper;
using Farmfresh.Context;
using Farmfresh.Models;
using Microsoft.EntityFrameworkCore;

namespace Farmfresh.Repositories.Categories;

public class CategoryRepository : ICategoryRepository
{
    private readonly FarmfreshDbContext _dbContext;
    private readonly IMapper _mapper;

    public CategoryRepository(FarmfreshDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<Category>> GetAll()
    {
        var result = await _dbContext.Categories.ToListAsync();
        var categories = _mapper.Map<IEnumerable<Category>>(result);
        return categories;
    }

    public async Task<Category> GetById(int categoryId)
    {
        return _mapper.Map<Category>(await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == categoryId));
    }

    public async Task<Category> AddCategory(Category category)
    {
        var result = await _dbContext.Categories.AddAsync(_mapper.Map<Entities.Category>(category));
        await _dbContext.SaveChangesAsync();
        return _mapper.Map<Category>(result.Entity);
    }

    public async Task<Category> UpdateCategory(int categoryId, Category category)
    {
        var result = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);
        if (result != null)
        {
            result.Name = category.Name;
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<Category>(result);
        }
        return null;
    }
    
    public async Task<bool> DeleteCategory(int categoryId)
    {
        var result = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);
        if (result != null)
        {
            _dbContext.Remove(result);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        return false;
    }
}