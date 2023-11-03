using Book.uz.Entities;

namespace Book.uz.Repositories.OrderRepository;

public interface IOrderRepository
{
    Task<Order> AddOrder(Order order);
    Task<ICollection<Order>> GetOrder();
    Task<Order?> GetOrderById(Guid id);
    Task DeleteOrder(Order order);
    
}