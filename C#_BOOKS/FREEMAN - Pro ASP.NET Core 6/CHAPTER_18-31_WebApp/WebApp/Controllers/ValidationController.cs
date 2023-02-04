using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ValidationController : ControllerBase
{
    private readonly DataContext _dataContext;

    public ValidationController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [HttpGet("productkey")]
    public bool ProductKey(string? productId, [FromQuery] KeyTarget keyTarget)
    {
        return long.TryParse(productId, out long keyValue) && _dataContext.Products.Find(keyValue) != null;
    }

    [HttpGet("categorykey")]
    public bool CategoryKey(string? categoryId, [FromQuery] KeyTarget keyTarget)
    {
        return long.TryParse(categoryId, out long keyValue) && _dataContext.Categories.Find(keyValue) != null;
    }

    [HttpGet("supplierkey")]
    public bool SupplierKey(string? supplierId, [FromQuery] KeyTarget keyTarget)
    {
        return long.TryParse(supplierId, out long keyValue) && _dataContext.Suppliers.Find(keyValue) != null;
    }

    [Bind(Prefix = "Product")]
    public class KeyTarget
    {
        public string? ProductId { get; set; }
        public string? CategoryId { get; set; }
        public string? SupplierId { get; set; }
    }
}
