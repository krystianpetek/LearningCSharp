using ContosoPizzaApi.Models;
using ContosoPizzaApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizzaApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    public PizzaController() { }

    [HttpGet]
    public ActionResult<List<Pizza>> GetAll()
    {
        return PizzaService.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<Pizza> GetById(int id)
    {
        var pizza = PizzaService.Get(id);

        if (pizza is null)
            return NotFound();

        return pizza;
    }

    [HttpPost]
    public async Task<IActionResult> Create(Pizza pizza)
    {
        await PizzaService.Add(pizza);
        return CreatedAtAction(nameof(Create), new { id = pizza.Id }, pizza);
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, Pizza pizza)
    {
        if (id < 0 || pizza is null || id != pizza.Id)
            return BadRequest();

        var existingPizza = PizzaService.Get(id);
        if (existingPizza is null)
            return NotFound();

        pizza.Id = id;
        PizzaService.Update(pizza);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (id < 0)
            return BadRequest();

        var pizza = PizzaService.Get(id);
        if (pizza is null)
            return NotFound();

        PizzaService.Delete(id);

        return NoContent();
    }
}
