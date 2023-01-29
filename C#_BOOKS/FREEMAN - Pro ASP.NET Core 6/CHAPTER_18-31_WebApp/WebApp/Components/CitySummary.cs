using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using WebApp.Models;

namespace WebApp.Components;

public class CitySummary : ViewComponent
{
    private CitiesData _citiesData;

    public CitySummary(CitiesData citiesData)
    {
        _citiesData = citiesData;
    }

    public IViewComponentResult Invoke()
    {
        return new HtmlContentViewComponentResult(new HtmlString("This is a <h3><i>string</i><h3>"));
        return View(new CityViewModel
        {
            Cities = _citiesData.Cities.Count(),
            Population = _citiesData.Cities.Sum(city => city.Population)
        });
        return Content("This is a <h3><i>string</i><h3>");

    }
}
