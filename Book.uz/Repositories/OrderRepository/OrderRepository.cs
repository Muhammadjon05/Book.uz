using AutoMapper;
using Book.uz.DbContext;
using Book.uz.DtoModels;
using Book.uz.Entities;
using Book.uz.Filter;
using Book.uz.Models;
using Book.uz.PaginationModels;
using Book.uz.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace Book.uz.Repositories.OrderRepository;

public class OrderRepository : IOrderRepository
{
    private readonly HttpContextHelper _httpContext;
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Order> _orderRepository;
    public OrderRepository(HttpContextHelper httpContext, IMapper mapper, IGenericRepository<Order> orderRepository)
    {
        _httpContext = httpContext;
        _mapper = mapper;
        _orderRepository = orderRepository;
    }

    public async ValueTask<OrderModel> InsertAsync(OrderDto dto)
    {
        var create = _mapper.Map<Order>(dto);
        var newBook = await _orderRepository.InsertAsync(create);
        return _mapper.Map<OrderModel>(newBook);
        
    }

    public ValueTask<IEnumerable<OrderModel>> GetAllAsync(OrderFilter filter)
    {
        throw new NotImplementedException();
    }

    public ValueTask<OrderModel> GetOrderById(Guid id)
    {
        throw new NotImplementedException();
    }

    public void DeleteOrder(Guid id)
    {
        throw new NotImplementedException();
    }
}