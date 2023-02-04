﻿using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SupplierController : ControllerBase
{
    private readonly DataContext _dataContext;

    public SupplierController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [HttpGet("{id}")]
    public async Task<Supplier?> GetSupplierAsync(long id)
    {
        Supplier? supplier = await _dataContext.Suppliers.Include(supplier => supplier.Products).FirstOrDefaultAsync(x => x.SupplierId == id);

        if(supplier?.Products != null)
        {
            foreach(Product product in supplier.Products)
            {
                product.Supplier = null;
            }
        }
        return supplier;
    }

    [HttpPatch("{id}")]
    public async Task<Supplier?> PatchSupplier(long id, JsonPatchDocument<Supplier>patchSupplier)
    {
        Supplier? supplier = await _dataContext.Suppliers.FirstOrDefaultAsync(x => x.SupplierId == id);
        if(supplier != null) {
            patchSupplier.ApplyTo(supplier);
            await _dataContext.SaveChangesAsync();
        }
        return supplier;
    }
}
