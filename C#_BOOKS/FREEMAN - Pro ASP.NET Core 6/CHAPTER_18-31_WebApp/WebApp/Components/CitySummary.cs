using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using WebApp.Models;

namespace WebApp.Components;

public class CitySummary : ViewComponent
{
    private CitiesData _citiesData;

    public CitySummary(CitiesData citiesData)
    {
        _citiesData = citiesData;
    }

    public IViewComponentResult Invoke(string themeName)
    {
        ViewBag.Theme = themeName;

        return View(new CityViewModel
        {
            Cities = _citiesData.Cities.Count(),
            Population = _citiesData.Cities.Sum(city => city.Population)
        });

        if (RouteData.Values["controller"] != null)
        {
            return View(new CityViewModel
            {
                Cities = _citiesData.Cities.Count(),
                Population = _citiesData.Cities.Sum(city => city.Population)
            });
        }
        else
        {
            return new HtmlContentViewComponentResult(new HtmlString("This is a <h3><i>string</i><h3>"));
        }
        return Content("This is a <h3><i>string</i><h3>");

    }
}
