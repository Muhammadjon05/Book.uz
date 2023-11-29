using AutoMapper;
using BookShop.Domain.DtoModels;
using BookShop.Domain.Entities;
using BookShop.Service.Extensions;
using BookShop.Service.Filter;
using BookShop.Service.PaginationModels;
using BookShop.Service.Repositories.BookRepository;
using BookShop.Service.Repositories.Generic;
using BookShop.ViewModel.Models;
using BookShop.Web.Exceptions;

namespace BookShop.Service.Repositories.OrderRepository;

public class OrderRepository : IOrderRepository
{
    private readonly HttpContextHelper _httpContext;
    private readonly UserProvider.UserProvider _userProvider;
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Order> _orderRepository;
    private readonly IBookRepository _bookRepository;
    public OrderRepository(HttpContextHelper httpContext, IMapper mapper, IGenericRepository<Order> orderRepository, UserProvider.UserProvider userProvider, IBookRepository bookRepository)
    {
        _httpContext = httpContext;
        _mapper = mapper;
        _orderRepository = orderRepository;
        _userProvider = userProvider;
        _bookRepository = bookRepository;
    }

    public async ValueTask<OrderModel> InsertAsync(OrderDto dto)
    {
        
        var create = _mapper.Map<Order>(dto);
        var book = await _bookRepository.GetBookByIdAsync(dto.BookId);
        create.TotalPrice = dto.Quantity * book.Price;
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