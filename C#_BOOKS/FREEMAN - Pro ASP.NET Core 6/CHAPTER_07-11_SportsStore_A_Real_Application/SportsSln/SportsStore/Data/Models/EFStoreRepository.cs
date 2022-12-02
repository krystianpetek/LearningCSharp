using Microsoft.EntityFrameworkCore;
using SportsStore.Data.DbContexts;
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

    public async Task CreateProductAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteProductAsync(Product product)
    {
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }

    public async Task ModifyProductAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task SaveProductAsync(Product product)
    {
        await _context.SaveChangesAsync();
    }
}