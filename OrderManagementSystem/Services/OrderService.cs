using OrderManagementSystem.DTOs;
using OrderManagementSystem.Models;
using OrderManagementSystem.Repositories;

namespace OrderManagementSystem.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<Order> CreateOrderAsync(CreateOrderDto dto)
        {
            foreach (var item in dto.Items)
            {
                var product = await _productRepository.GetByIdAsync(item.ProductId);
                if (product == null || product.Stock < item.Quantity)
                {
                    throw new InvalidOperationException($"Yetersiz stok: {item.ProductId}");
                }
                product.Stock -= item.Quantity;
            }

            var order = new Order
            {
                UserId = dto.UserId,
                Items = dto.Items.Select(i => new OrderItem
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity
                }).ToList()
            };

            await _orderRepository.AddAsync(order);
            return order;
        }

        public async Task<List<Order>> GetOrdersByUserAsync(string userId)
        {
            return await _orderRepository.GetByUserIdAsync(userId);
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _orderRepository.GetByIdAsync(id);
        }

        public async Task DeleteOrderAsync(int id)
        {
            await _orderRepository.DeleteAsync(id);
        }
    }
}
