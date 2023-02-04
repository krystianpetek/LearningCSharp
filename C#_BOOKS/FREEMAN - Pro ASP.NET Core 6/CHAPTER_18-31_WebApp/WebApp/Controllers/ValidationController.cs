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
    public bool ProductKey(string productId)
    {
        return long.TryParse(productId, out long keyValue) && _dataContext.Products.Find(keyValue) != null;
    }

    [HttpGet("categorykey")]
    public bool CategoryKey(string categoryId)
    {
        return long.TryParse(categoryId, out long keyValue) && _dataContext.Categories.Find(keyValue) != null;
    }

    [HttpGet("supplierkey")]
    public bool SupplierKey(string supplierId)
    {
        return long.TryParse(supplierId, out long keyValue) && _dataContext.Suppliers.Find(keyValue) != null;
    }
}
