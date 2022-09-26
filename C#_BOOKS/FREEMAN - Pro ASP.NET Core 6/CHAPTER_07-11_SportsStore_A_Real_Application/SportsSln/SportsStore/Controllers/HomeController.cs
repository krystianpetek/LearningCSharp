using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.ViewModels;

namespace SportsStore.Controllers;

public class HomeController : Controller
{
    public int PageSize { get; set; } = 4;

    private readonly IStoreRepository _repository;

    public HomeController(IStoreRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult Index(int productPage = 1) => View("Index", 
        new ProductsListViewModel()
        {
            Products = _repository.Products
                .OrderBy(p => p.ProductId)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize),
            
            PagingInfo = new PagingInfo()
                {
                    CurrentPage = productPage,
                    TotalItems = _repository.Products.Count(),
                    ItemsPerPage = PageSize
                }
        });
}