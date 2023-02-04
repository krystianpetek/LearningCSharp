using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using WebApp.Models;

namespace WebApp.Controllers;

[ViewComponent(Name = "CitiesControllerHybrid")]
public class CitiesController : Controller
{
    private readonly CitiesData _citiesData;

    public CitiesController(CitiesData citiesData)
    {
        _citiesData = citiesData;
    }

    public IActionResult Index()
    {
        return View(_citiesData.Cities);
    }

    public IViewComponentResult Invoke()
    {
        return new ViewViewComponentResult()
        {
            ViewData = new ViewDataDictionary<CityViewModel>(
            ViewData,
            new CityViewModel
            {
                Cities = _citiesData.Cities.Count(),
                Population = _citiesData.Cities.Sum(c => c.Population)
            })
        };
    }
}
