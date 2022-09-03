using ContosoPizzaAPI_NET6_0.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizzaAPI_NET6_0.Data
{
    public class PizzaContext : DbContext
    {
        public PizzaContext(DbContextOptions<PizzaContext> options) : base(options)
        {

        }
        public DbSet<Pizza> Pizzas => Set<Pizza>();
        public DbSet<Topping> Toppings => Set<Topping>();
        public DbSet<Sauce> Sauces => Set<Sauce>();

    }
}
