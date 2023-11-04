/*using AutoMapper;
using Book.uz.DtoModels;
using Book.uz.Entities;
using Book.uz.Exceptions;
using Book.uz.Models;
using Book.uz.Repositories.OrderRepository;

namespace Book.uz.Manager.OrderManager;

public class OrderManager
{
    private readonly IMapper _mapper;
    private readonly UserProvider.UserProvider _userProvider;
    private readonly IOrderRepository _orderRepository;

    public OrderManager(IOrderRepository orderRepository, IMapper mapper, UserProvider.UserProvider userProvider)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
        _userProvider = userProvider;
    }

    public  async Task<OrderModel> AddOrder(OrderDto dto)
    {
        var orderMap = _mapper.Map<Order>(dto);
        orderMap.UserId = _userProvider.UserId;
        var order = await _orderRepository.AddOrder(orderMap);
        return _mapper.Map<OrderModel>(order);
    }

    public async Task<ICollection<OrderModel>> GetOrders()
    {
        var orders = await _orderRepository.GetOrders();
        return _mapper.Map<ICollection<OrderModel>>(orders);
    }

    public async Task<OrderModel> GetOrderById(Guid id)
    {
        var order = await _orderRepository.GetOrderById(id);
        if (order == null)
        {
            throw new OrderException(id);
        }
        return _mapper.Map<OrderModel>(order);
    }

    public async Task DeleteOrder(Guid id)
    {
        var order = await _orderRepository.GetOrderById(id);
        if (order == null)
        {
            throw new OrderException(id);
        }
        await _orderRepository.DeleteOrder(order);

       
    }
    public async Task<ICollection<OrderModel>> GetCurrentUsersOrder()
    {
        var userId = _userProvider.UserId;
        var orders = await _orderRepository.GetOrders();
        var currentUserOrders = orders.Where(i => i.UserId == userId).ToList();
        return _mapper.Map<ICollection<OrderModel>>(currentUserOrders);
    }
}*/