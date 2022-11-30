using Microsoft.AspNetCore.Mvc;
using SportsStore.Data.Interface;

namespace SportsStore.Components;

public class NavigationMenuViewComponent : ViewComponent
{
    private IStoreRepository _repository;

    public NavigationMenuViewComponent(IStoreRepository repository)
    {
        _repository = repository;
    }
    
    public IViewComponentResult Invoke()
    {
        ViewBag.SelectedCategory = RouteData?.Values["category"]!;
        return View("Default",_repository.Products
            .Select(x => x.Category)
            .Distinct()
            .OrderBy(x => x));
    }
}