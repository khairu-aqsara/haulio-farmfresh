using Farmfresh.Models;

namespace Farmfresh.Repositories.Products
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll(string? keyword, int pageNumber, int pageSize);
        Task<IEnumerable<Product>> GetByCategoryId(int categoryId, int pageNumber, int pageSize);
        Task<Product> GetById(int id);
        Task<Product> Add(Product product);
        Task<Product> Update(int id, Product product);
        Task<bool> Delete(int id);
    }
}
