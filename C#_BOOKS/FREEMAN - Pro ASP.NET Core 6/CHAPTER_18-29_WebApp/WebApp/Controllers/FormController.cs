﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using WebApp.Models;

namespace WebApp.Controllers;

public class FormController : Controller
{
    private readonly DataContext _dataContext;

    public FormController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<IActionResult> Index([FromRoute] long? id)
    {
        ViewBag.Categories = new SelectList(_dataContext.Categories, "CategoryId", "Name");
        return View("Form",
            await _dataContext.Products
            .Include(supplier => supplier.Supplier)
            .Include(category => category.Category)
            .FirstOrDefaultAsync(product => product.ProductId == id));
    }

    [HttpPost]
    public IActionResult SubmitForm(
        //string name, decimal price
        //Product product,
        [Bind(Prefix = "Category")] Category category,
        [Bind("ProductId","Name","Price","CategoryId","SupplierId")] Product product
        )
    {
        if (ModelState.GetValidationState(nameof(Product.Price)) == ModelValidationState.Valid && 
            product.Price <= 0)
        {
            ModelState.AddModelError(nameof(product.Price), "Enter a positive price");
        }
        if (ModelState.GetValidationState(nameof(Product.Name)) == ModelValidationState.Valid &&
            ModelState.GetValidationState(nameof(Product.Price)) == ModelValidationState.Valid && 
            product.Name.ToLower().StartsWith("small") &&
            product.Price > 100){
            ModelState.AddModelError("", "Small products cannot cost more than $100");
        }
        if(ModelState.GetValidationState(nameof(product.SupplierId)) == ModelValidationState.Valid && 
            !_dataContext.Suppliers.Any(supplier => supplier.SupplierId == product.SupplierId))
        {
            ModelState.AddModelError(nameof(product.SupplierId), "Enter an existing supplier ID");
        }
        if(ModelState.GetValidationState(nameof(product.CategoryId)) == ModelValidationState.Valid && 
            !_dataContext.Categories.Any(category => category.CategoryId == product.CategoryId))
        {
            ModelState.AddModelError(nameof(product.SupplierId), "Enter an existing supplier ID");
        }

        if (ModelState.IsValid)
        {
            TempData["name param"] = product.Name;
            TempData["price param"] = $"{product.Price}";
            TempData["product"] = JsonSerializer.Serialize(product);
            TempData["category"] = JsonSerializer.Serialize(category);
            foreach (string key in Request.Form.Keys /*.Where(key => !key.StartsWith("_"))*/ )
            {
                TempData[key] = string.Join(", ", Request.Form[key]);
            }
            return RedirectToAction(nameof(Results));
        }
        else
        {
            return View("Form");
        }
    }

    public IActionResult Results()
    {
        return View();
    }

    public string Header([FromHeader(Name = "Accept-Language")] string accept)
    {
        return $"Header: {accept}";
    }

    [IgnoreAntiforgeryToken]
    [HttpPost]
    public Product Body([FromBody] Product product)
    {
        return product;
    }
}