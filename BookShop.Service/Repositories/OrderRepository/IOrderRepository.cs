using BookShop.Domain.DtoModels;
using BookShop.Service.Filter;
using BookShop.ViewModel.Models;

namespace BookShop.Service.Repositories.OrderRepository;

public interface IOrderRepository
{
    ValueTask<OrderModel> InsertAsync(OrderDto dto);
    ValueTask<IEnumerable<OrderModel>> GetAllAsync(OrderFilter filter);
    ValueTask<OrderModel> GetOrderById(Guid id);
    void DeleteOrder(Guid id);
    
}