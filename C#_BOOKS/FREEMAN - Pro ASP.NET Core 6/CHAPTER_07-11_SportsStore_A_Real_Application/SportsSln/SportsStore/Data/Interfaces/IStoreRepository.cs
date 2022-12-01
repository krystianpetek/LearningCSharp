using SportsStore.Models;

namespace SportsStore.Data.Interface;

public interface IStoreRepository
{
    IQueryable<Product> Products { get; }

    Task SaveProduct(Product product);
    Task ModifyProduct(Product product);
    Task CreateProduct(Product product);
    Task DeleteProduct(Product product);
}