using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using WebApp.Models.ViewModels;

namespace WebApp.Controllers;

[AutoValidateAntiforgeryToken]
public class FormController : Controller
{
    private readonly DataContext _dataContext;
    private IEnumerable<Category> _categories => _dataContext.Categories;
    private IEnumerable<Supplier> _suppliers => _dataContext.Suppliers;

    public FormController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public IActionResult Index()
    {
        return View(_dataContext.Products
            .Include(product => product.Category)
            .Include(product => product.Supplier));
    }

    public IActionResult Details(long id)
    {
        Product? product = _dataContext.Products
            .Include(product => product.Category)
            .Include(product => product.Supplier)
            .FirstOrDefault(product => product.ProductId == id);

        ProductViewModel productViewModel = ProductViewModelFactory.Details(product);
        return View(
            viewName: "ProductEditor",
            model: productViewModel);
    }

    [HttpGet]
    public IActionResult Create()
    {
        ProductViewModel productViewModel = ProductViewModelFactory.Create(new Product(), _categories, _suppliers);
        return View(
            viewName: "ProductEditor",
            model: productViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] Product product)
    {
        if (ModelState.IsValid)
        {
            product.ProductId = default;
            product.Category = default;
            product.Supplier = default;
            _dataContext.Add(product);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(
            viewName: "ProductEditor",
            model: ProductViewModelFactory.Create(product, _categories, _suppliers));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(long id)
    {
        Product? product = await _dataContext.Products.FindAsync(id);
        if (product != null)
        {
            ProductViewModel productViewModel = ProductViewModelFactory.Edit(product, _categories, _suppliers);
            return View(
                viewName: "ProductEditor",
                model: productViewModel);
        }
        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Edit([FromForm] Product product)
    {
        if (ModelState.IsValid)
        {
            product.Category = default;
            product.Supplier = default;
            _dataContext.Products.Update(product);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(
            viewName: "ProductEditor",
            model: ProductViewModelFactory.Edit(product, _categories, _suppliers));
    }

    [HttpGet]
    public async Task<IActionResult> Delete(long id)
    {
        Product? product = await _dataContext.Products.FindAsync(id);
        if (product != null)
        {
            ProductViewModel productViewModel = ProductViewModelFactory.Delete(product, _categories, _suppliers);
            return View(
                viewName: "ProductEditor",
                model: productViewModel);
        }
        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Delete([FromForm] Product product)
    {
        _dataContext.Products.Remove(product);
        await _dataContext.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
