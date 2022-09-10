using BlazingPizzaSite.Data;
using BlazingPizzaSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazingPizzaSite.Controllers;

[Route("specials")]
[ApiController]
public class SpecialsController : Controller
{
    private readonly PizzaStoreContext _dbContext;
    public SpecialsController(PizzaStoreContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<List<PizzaSpecial>>> GetSpecials()
    {
        var specials = (await _dbContext.Specials.ToListAsync()).OrderByDescending(x => x.BasePrice).ToList();
        return specials;
    }
}
