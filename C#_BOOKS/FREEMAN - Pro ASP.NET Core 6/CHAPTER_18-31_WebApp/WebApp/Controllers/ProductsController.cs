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
    public async Task<IActionResult> SaveProduct([FromBody] Product product)
    {
        await _dataContext.Products.AddAsync(product);
        await _dataContext.SaveChangesAsync();
        return Created($"{product.ProductId}", product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(long id, [FromBody] Product product)
    {
        var entity = await _dataContext.Products.FirstOrDefaultAsync(x => x.ProductId == id);
        if (entity != null)
        {
            entity.CategoryId = product.CategoryId;
            entity.SupplierId = product.SupplierId;
            entity.Name = product.Name;
            entity.Price = product.Price;

            await _dataContext.SaveChangesAsync();
            return Ok();
        }
        _dataContext.Products.Update(product);
        await _dataContext.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(long id)
    {
        _dataContext.Products.Remove(new Product() { ProductId = id });
        await _dataContext.SaveChangesAsync();

        return Ok();
    }
}
