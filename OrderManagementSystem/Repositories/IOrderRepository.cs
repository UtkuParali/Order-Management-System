using OrderManagementSystem.Models;

namespace OrderManagementSystem.Repositories
{
    public interface IOrderRepository
    {
        Task AddAsync(Order order);
        Task<List<Order>> GetByUserIdAsync(string userId);
        Task<Order> GetByIdAsync(int id);
        Task DeleteAsync(int id);
    }
}
