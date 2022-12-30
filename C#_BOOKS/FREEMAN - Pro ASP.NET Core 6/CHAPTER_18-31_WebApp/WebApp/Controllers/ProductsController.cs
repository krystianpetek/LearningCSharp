using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebApp.Models;
using WebApp.Routes;

namespace WebApp.Controllers;

[Route($"{ApiRoutes.Products}")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly DataContext _dataContext;
    public ProductsController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [HttpGet]
    public async Task<IEnumerable<Product>> GetProducts()
    {
        IEnumerable<Product> products = _dataContext.Products;
        return await Task.FromResult(products);
    }

    [HttpGet("{id:int}")]
    public async Task<Product?> GetProduct(int id, [FromServices] ILogger<ProductsController> logger)
    {
        logger.LogDebug("GetProduct Action Invoked");
        
        Product? product = await _dataContext.Products.FirstOrDefaultAsync(c => c.ProductId == id);
        return product;
    }

    [HttpPost]
    public async Task<ActionResult> SaveProduct([FromBody] Product product)
    {
        await _dataContext.Products.AddAsync(product);
        await _dataContext.SaveChangesAsync();
        return Created($"{product.ProductId}",product);
    }
}
