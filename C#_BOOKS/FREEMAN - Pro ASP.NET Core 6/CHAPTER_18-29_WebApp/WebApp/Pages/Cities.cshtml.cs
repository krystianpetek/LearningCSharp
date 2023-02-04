using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using WebApp.Models;

namespace WebApp.Pages;

[ViewComponent(Name = "CitiesPageHybrid")]
public class CitiesModel : PageModel
{
    public CitiesData? CitiesData { get; set; }

    public CitiesModel(CitiesData citiesData)
    {
        CitiesData = citiesData;
    }

    [ViewComponentContext]
    public ViewComponentContext Context { get; set; } = new ViewComponentContext();

    public IViewComponentResult Invoke()
    {
        return new ViewViewComponentResult()
        {
            ViewData = new ViewDataDictionary<CityViewModel>(
                Context.ViewData
                , new CityViewModel
                {
                    Cities = CitiesData?.Cities.Count(),
                    Population = CitiesData?.Cities.Sum(city => city.Population)
                })
        };
    }
}
