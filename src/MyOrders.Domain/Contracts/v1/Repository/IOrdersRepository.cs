using MyOrders.Domain.Entities.v1;

namespace MyOrders.Domain.Contracts.v1.Repository;

public interface IOrdersRepository
{
    Task<IEnumerable<Order>> GetOrdersAsync();
    Task<Order> GetOrderByIdAsync(int id);
    Task<Order> CreateOrderAsync(Order order);
    Task<int> UpdateOrderAsync(Order order);
    Task<int> DeleteOrderAsync(Order order);
}
