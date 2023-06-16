using Farmfresh.Models;
using Farmfresh.Repositories.Products;

namespace Farmfresh.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Add(Product product)
        {
            var result = await _productRepository.Add(product);
            return result;

        }

        public async Task<bool> Delete(int id)
        {
            var deleted = await _productRepository.Delete(id);
            return deleted;
        }

        public async Task<IEnumerable<Product>> GetAll(string? keyword, int pageNumber, int pageSize)
        {
            var result = await _productRepository.GetAll(keyword,pageNumber, pageSize);
            return result;
        }

        public async Task<IEnumerable<Product>> GetByCategoryId(int categoryId, int pageNumber, int pageSize)
        {
            var result = await _productRepository.GetByCategoryId(categoryId, pageNumber, pageSize);
            return result;
        }

        public async Task<Product> GetById(int id)
        {
            var result = await _productRepository.GetById(id);  
            return result;
        }

        public async Task<Product> Update(int id, Product product)
        {
            var result = await _productRepository.Update(id, product);
            return result;
        }
    }
}
