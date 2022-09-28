using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
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
    public IActionResult Index(string? category, int productPage = 1) => View("Index", 
        new ProductsListViewModel()
        {
            Products = _repository.Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductId)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize),
            
            PagingInfo = new PagingInfo()
            {
                CurrentPage = productPage,
                TotalItems = _repository.Products.Count(x => category == null || x.Category == category),
                ItemsPerPage = PageSize
            },
            CurrentCategory = category
        });
}