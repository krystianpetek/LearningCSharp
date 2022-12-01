using Microsoft.EntityFrameworkCore;
using SportsStore.Data.Interface;
using SportsStore.Models;

namespace SportsStore.Data.Models;

public class EFStoreRepository : IStoreRepository
{
    private StoreDbContext _context;

    public EFStoreRepository(StoreDbContext context)
    {
        _context = context;
    }

    public IQueryable<Product> Products => _context.Products;

    public async Task CreateProduct(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteProduct(Product product)
    {
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }

    public async Task ModifyProduct(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task SaveProduct(Product product)
    {
        await _context.SaveChangesAsync();
    }
}