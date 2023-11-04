using Book.uz.DtoModels;
using Book.uz.Entities;
using Book.uz.Filter;
using Book.uz.Models;

namespace Book.uz.Repositories.OrderRepository;

public interface IOrderRepository
{
    ValueTask<OrderModel> InsertAsync(OrderDto dto);
    ValueTask<IEnumerable<OrderModel>> GetAllAsync(OrderFilter filter);
    ValueTask<OrderModel> GetOrderById(Guid id);
    void DeleteOrder(Guid id);
    
}