using Book.uz.Entities;
using Book.uz.Repositories.OrderRepository;

namespace Book.uz.Manager.OrderManager;

public class OrderManager 
{
    private readonly IOrderRepository _orderRepository;

    public OrderManager(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public Task<Order> AddOrder(Order order)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Order>> GetOrder()
    {
        throw new NotImplementedException();
    }

    public Task<Order?> GetOrderById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteOrder(Order order)
    {
        throw new NotImplementedException();
    }
}