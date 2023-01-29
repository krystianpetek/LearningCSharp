using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Components;

public class CitySummary : ViewComponent
{
    private CitiesData _citiesData;

    public CitySummary(CitiesData citiesData)
    {
        _citiesData = citiesData;
    }

    public string Invoke()
    {
        return $"{_citiesData.Cities.Count()} cities, " +
            $"{_citiesData.Cities.Sum(city => city.Population)} people";
    }
}
