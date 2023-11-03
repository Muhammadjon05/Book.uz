
using Book.uz.DtoModels;
using Book.uz.Exceptions;
using Book.uz.Manager.OrderManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Book.uz.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly OrderManager _orderManager;

    public OrdersController(OrderManager orderManager)
    {
        _orderManager = orderManager;
    }

    [HttpPost]
    public async Task<IActionResult> AddOrder(OrderDto dto)
    {
        var order = await _orderManager.AddOrder(dto);
        return Ok(order);
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders()
    {
        var orders = await _orderManager.GetOrders();
        return Ok(orders);
    }

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
            await _orderManager.DeleteOrder(id);
            return Ok("Successfully deleted!");

        }
        catch (OrderException e)
        {
            return NotFound("Order not found");
        }
    }
}