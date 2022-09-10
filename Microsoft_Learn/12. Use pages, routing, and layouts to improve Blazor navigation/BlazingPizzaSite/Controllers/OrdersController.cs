using BlazingPizzaSite.Data;
using BlazingPizzaSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazingPizzaSite.Controllers;

[Route("orders")]
[ApiController]
public class OrdersController : Controller
{
    private readonly PizzaStoreContext _dbContext;
    public OrdersController(PizzaStoreContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<List<OrderWithStatus>>> GetOrders()
    {
        var orders = await _dbContext.Orders
            .Include(o => o.Pizzas)
                .ThenInclude(p => p.Special)
            .Include(o => o.Pizzas)
                .ThenInclude(p => p.Toppings)
                .ThenInclude(t => t.Topping)
            .OrderByDescending(o => o.CreatedTime)
            .ToListAsync();

        return orders.Select(o => OrderWithStatus.FromOrder(o)).ToList();
    }

    [HttpPost]
    public async Task<ActionResult<int>> PlaceOrder(Order order)
    {
        order.CreatedTime = DateTime.Now;

        foreach (var pizza in order.Pizzas)
        {
            pizza.SpecialId = pizza.Special.Id;
            pizza.Special = null;
        }

        _dbContext.Orders.Attach(order);
        await _dbContext.SaveChangesAsync();

        return order.OrderId;
    }
}
