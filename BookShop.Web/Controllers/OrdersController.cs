using BookShop.Domain.DtoModels;
using BookShop.Service.Filter;
using BookShop.Service.Repositories.OrderRepository;
using BookShop.Web.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Web.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderRepository _orderManager;

    public OrdersController(IOrderRepository orderManager)
    {
        _orderManager = orderManager;
    }

    [HttpPost]
    public async Task<IActionResult> AddOrder(OrderDto dto)
    {
        var order = await _orderManager.InsertAsync(dto);
        return Ok(order);
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders([FromQuery] OrderFilter filter)
    {
        var orders = await _orderManager.GetAllAsync(filter);
        return Ok(orders);
    }

    /*
    [HttpGet("CurrentUserOrders")]
    public async Task<IActionResult> CurrentUserOrders()
    {
        var orders = await _orderManager.GetAllAsync();
        return Ok(orders);
    }*/
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderById(Guid id)
    {
        try
        {
            var order = await _orderManager.GetOrderById(id);
            return Ok(order);

        }
        catch (OrderException e)
        {
            return NotFound("Order not found");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(Guid id)
    {
        try
        {
             _orderManager.DeleteOrder(id);
            return Ok("Successfully deleted!");

        }
        catch (OrderException e)
        {
            return NotFound("Order not found");
        }
    }
}