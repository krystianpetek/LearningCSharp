using BlazingPizzaSite.Data;
using BlazingPizzaSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazingPizzaSite.Controllers;

[Route("oldPizza")]
[ApiController]
public class OldPizzaController : Controller
{
    private readonly PizzaStoreContext _dbContext;
    public OldPizzaController(PizzaStoreContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<List<OldPizza>>> GetSpecials()
    {
        var oldpizzas = await _dbContext.OldPizzas.ToListAsync();
        return oldpizzas;
    }
}
