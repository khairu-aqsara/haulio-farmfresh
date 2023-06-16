using AutoMapper;
using Farmfresh.Context;
using Farmfresh.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Farmfresh.Repositories.Helpers;

namespace Farmfresh.Repositories.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly FarmfreshDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductRepository(FarmfreshDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Product> Add(Product product)
        {
            var result = await _dbContext.Products.AddAsync(_mapper.Map<Entities.Product>(product));
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<Product>(result.Entity);
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _dbContext.Products.FirstOrDefaultAsync(c => c.Id == id);
            if (result != null)
            {
                _dbContext.Remove(result);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Product>> GetAll(string? keyword, int pageNumber, int pageSize)
        {
            var itemsToSkip = (pageNumber - 1) * pageSize;

            var result = await _dbContext.Products.Include(c => c.Category)
                .Include(c => c.Category)
                .WhereIf(!string.IsNullOrEmpty(keyword.ToLower()), 
                    r => r.Name.ToLower().Contains(keyword) || r.Category.Name.ToLower().Contains(keyword.ToLower()))
                .Skip(itemsToSkip).Take(pageSize)
                .ToListAsync();
            return _mapper.Map<IEnumerable<Product>>(result);
        }

        public async Task<IEnumerable<Product>> GetByCategoryId(int categoryId, int pageNumber, int pageSize)
        {
            var itemsToSkip = (pageNumber - 1) * pageSize;

            var result= await _dbContext.Products.Where(c => c.CategoryId == categoryId)
                .Skip(itemsToSkip).Take(pageSize)
                .Include(c => c.Category)
                .ToListAsync();
            return _mapper.Map<IEnumerable<Product>>(result);
        }

        public async Task<Product> GetById(int id)
        {
            var result  = await _dbContext.Products
                .Include(c => c.Category)
                .FirstOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<Product>(result);
        }

        public async Task<Product> Update(int id, Product product)
        {
            var result = await _dbContext.Products.FirstOrDefaultAsync(c => c.Id == id);
            if (result != null)
            {
                result.Name = product.Name;
                result.Price = product.Price;
                result.CategoryId = product.CategoryId;
                //result.Photo = product.Photo;

                await _dbContext.SaveChangesAsync();
                return _mapper.Map<Product>(result);
            }
            return null;
        }
    }
}
