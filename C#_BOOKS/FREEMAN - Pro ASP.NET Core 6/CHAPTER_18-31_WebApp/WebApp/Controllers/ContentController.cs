using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContentController : ControllerBase
{
    private readonly DataContext _dataContext;
    public ContentController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [HttpGet("string")]
    public string GetString()
    {
        return "This is a string response";
    }

    [Produces("application/json")]
    [HttpGet("object")]
    public async Task<ProductBindingTarget> GetObject()
    {
        Product product = await _dataContext.Products.FirstAsync();
        
        return new ProductBindingTarget()
        {
            Name = product.Name,
            Price = product.Price,
            CategoryId = product.CategoryId,
            SupplierId = product.SupplierId
        };
    }
}
