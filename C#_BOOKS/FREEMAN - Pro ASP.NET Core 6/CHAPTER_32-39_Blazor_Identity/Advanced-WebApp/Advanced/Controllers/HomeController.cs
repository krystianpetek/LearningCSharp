using Advanced.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Advanced.Controllers;
public class HomeController : Controller
{
    private readonly DataContext _dataContext;

    public HomeController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public IActionResult Index([FromQuery] string selectedCity)
    {
        return View(new PeopleListViewModel
        {
            People = _dataContext.People
            .Include(person => person.Department)
            .Include(person => person.Location),

            Cities = _dataContext.Locations.Select(location => location.City).Distinct(),

            SelectedCity = selectedCity
        });
    }
}

public class PeopleListViewModel
{
    public IEnumerable<Person> People { get; set; } = Enumerable.Empty<Person>();
    public IEnumerable<string> Cities{ get; set; } = Enumerable.Empty<string>();
    public string SelectedCity { get; set; } = string.Empty;

    public string GetClass(string? city) => SelectedCity == city ? "bg-info text-white" : "";
}
