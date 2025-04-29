using OrderManagementSystem.Models;

namespace OrderManagementSystem.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id);
        Task<List<Product>> GetAllAsync();
        Task UpdateAsync(Product product);
    }
}
