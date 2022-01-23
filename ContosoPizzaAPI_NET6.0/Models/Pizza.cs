using System.ComponentModel.DataAnnotations;
namespace ContosoPizzaAPI_NET6_0.Models;

public class Pizza
{
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string? Name { get; set; }

    public Sauce? Sauce { get; set; }

    public ICollection<Topping>? Toppings { get; set; }
}