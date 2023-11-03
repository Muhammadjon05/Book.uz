using Book.uz.Entities;

namespace Book.uz.Repositories.OrderRepository;

public interface IOrderRepository
{
    Task<Order> AddOrder(Order order);
    Task<ICollection<Order>> GetOrders();
    Task<Order?> GetOrderById(Guid id);
    Task DeleteOrder(Order order);
    
    
}