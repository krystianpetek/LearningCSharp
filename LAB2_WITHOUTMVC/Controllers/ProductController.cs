using LAB2_WITHOUTMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace LAB2_WITHOUTMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;
        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult List()
        {
            return View(productRepository.Products);
        }
    }
}
