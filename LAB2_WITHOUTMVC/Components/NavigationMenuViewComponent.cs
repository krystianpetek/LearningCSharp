using LAB2_WITHOUTMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace LAB2_WITHOUTMVC
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private readonly IProductRepository productRepository;
        public NavigationMenuViewComponent(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(productRepository.Products.Select(x => x.Category).Distinct().OrderBy(x => x));

        }
    }
}
