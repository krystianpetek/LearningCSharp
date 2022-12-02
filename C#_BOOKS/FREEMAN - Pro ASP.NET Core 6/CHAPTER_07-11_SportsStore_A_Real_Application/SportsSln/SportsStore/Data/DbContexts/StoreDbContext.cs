using Microsoft.EntityFrameworkCore;
using SportsStore.Models;

namespace SportsStore.Data.DbContexts;

public class StoreDbContext : DbContext
{
    public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
    { }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Order> Orders => Set<Order>();
}