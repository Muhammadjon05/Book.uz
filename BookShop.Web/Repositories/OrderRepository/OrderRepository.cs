﻿using AutoMapper;
using BookShop.Web.DbContext;
using BookShop.Web.Extensions;
using BookShop.Web.DtoModels;
using BookShop.Web.Entities;
using BookShop.Web.Exceptions;
using BookShop.Web.Filter;
using BookShop.Web.Models;
using BookShop.Web.PaginationModels;
using BookShop.Web.Repositories.Generic;

namespace BookShop.Web.Repositories.OrderRepository;

public class OrderRepository : IOrderRepository
{
    private readonly HttpContextHelper _httpContext;
    private readonly UserProvider.UserProvider _userProvider;
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Order> _orderRepository;
    public OrderRepository(HttpContextHelper httpContext, IMapper mapper, IGenericRepository<Order> orderRepository, UserProvider.UserProvider userProvider)
    {
        _httpContext = httpContext;
        _mapper = mapper;
        _orderRepository = orderRepository;
        _userProvider = userProvider;
    }

    public async ValueTask<OrderModel> InsertAsync(OrderDto dto)
    {
        var create = _mapper.Map<Order>(dto);
        create.UserId = _userProvider.UserId;
        var newBook = await _orderRepository.InsertAsync(create);
        return _mapper.Map<OrderModel>(newBook);
        
    }

    public async ValueTask<IEnumerable<OrderModel>> GetAllAsync(OrderFilter filter)
    {
        var orders = _orderRepository.SelectAll();
        if (filter.Quantity != null)
        {
            orders = orders.Where(t => t.Quantity > filter.Quantity);
        }if (filter.TotalPrice != null)
        {
            orders = orders.Where(t => t.TotalPrice > filter.TotalPrice);
        }
        if (filter.PaymentMethod != null)
        {
            orders = orders.Where(t => t.PaymentMethod == filter.PaymentMethod);
        }if (filter.PaymentStatus != null)
        {
            orders = orders.Where(t => t.PaymentStatus == filter.PaymentStatus);
        }
        var ordersPages = await orders.
            ToPagedListAsync(_httpContext, filter);
        
        return  ordersPages.Select(v=>_mapper.Map<OrderModel>(v));
    }

    public ValueTask<OrderModel> GetOrderById(Guid id)
    {
        var order =  _orderRepository.SelectFirstAsync
            (t => t.OrderId == id).Result;
        if (order == null)
            throw new OrderException(id);

        return ValueTask.FromResult(_mapper.Map<OrderModel>(order));
    }

    public void DeleteOrder(Guid id)
    {
        var order = _orderRepository.SelectFirstAsync
            (t => t.OrderId == id).Result;
        if (order == null)
            throw new OrderException(id);
        _orderRepository.DeleteAsync(order);
    }
}