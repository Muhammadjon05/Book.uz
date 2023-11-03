using Book.uz.DbContext;
using Book.uz.Entities;
using Microsoft.EntityFrameworkCore;

namespace Book.uz.Repositories.OrderRepository;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _appDbContext;

    public OrderRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Order> AddOrder(Order order)
    {
        await _appDbContext.Orders.AddAsync(order);
        await _appDbContext.SaveChangesAsync();
        return order;
    }

    public async Task<ICollection<Order>> GetOrder()
    {
        var list = await _appDbContext.Orders.ToListAsync();
        return list;
    }

    public async Task<Order?> GetOrderById(Guid id)
    {
        var order = await _appDbContext.Orders.Where(i => i.OrderId == id).FirstOrDefaultAsync();
        return order;

    }

    public async Task DeleteOrder(Order order)
    {
         _appDbContext.Remove(order);
         await _appDbContext.SaveChangesAsync();
    }
}