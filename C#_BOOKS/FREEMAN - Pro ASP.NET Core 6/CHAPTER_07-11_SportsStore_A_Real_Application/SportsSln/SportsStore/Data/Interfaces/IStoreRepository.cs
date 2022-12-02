using SportsStore.Models;

namespace SportsStore.Data.Interface;

public interface IStoreRepository
{
    IQueryable<Product> Products { get; }

    Task SaveProductAsync(Product product);
    Task ModifyProductAsync(Product product);
    Task CreateProductAsync(Product product);
    Task DeleteProductAsync(Product product);
}