using ContosoPizzaAPI.Models;
using ContosoPizzaAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ContosoPizzaAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PizzaController : Controller
    {
        [HttpGet]
        public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Pizza> GetId(int id)
        {
            var pizza = PizzaService.Get(id);
            if (pizza is null)
                return NotFound();
            return Ok(pizza);
        }

        [HttpPost]
        public IActionResult Add(Pizza pizza)
        {
            PizzaService.Add(pizza);
            return CreatedAtAction(nameof(Add), new { id = pizza.Id }, pizza);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza pizza)
        {
            if (id != pizza.Id)
                return BadRequest();

            var czyIstniejePizza = PizzaService.Get(id);
            if (czyIstniejePizza is null)
                return NotFound();

            PizzaService.Update(pizza);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var czyIstniejePizza = PizzaService.Get(id);
            if (czyIstniejePizza is null)
                return NotFound();

            PizzaService.Delete(id);
            return NoContent();
        }
    }
}
