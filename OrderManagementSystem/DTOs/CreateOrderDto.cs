namespace OrderManagementSystem.DTOs
{
    public class CreateOrderDto
    {
        public string UserId { get; set; }
        public List<OrderItemDto> Items { get; set; }
    }
}
