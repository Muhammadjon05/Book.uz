using BookShop.Web.Entities;
using BookShop.Web.DtoModels;
using BookShop.Web.Filter;
using BookShop.Web.Models;

namespace BookShop.Web.Repositories.OrderRepository;

public interface IOrderRepository
{
    ValueTask<OrderModel> InsertAsync(OrderDto dto);
    ValueTask<IEnumerable<OrderModel>> GetAllAsync(OrderFilter filter);
    ValueTask<OrderModel> GetOrderById(Guid id);
    void DeleteOrder(Guid id);
    
}