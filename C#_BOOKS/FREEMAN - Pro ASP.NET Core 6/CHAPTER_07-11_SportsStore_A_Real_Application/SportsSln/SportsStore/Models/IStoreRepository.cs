using Microsoft.Extensions.Caching.Memory;

namespace SportsStore.Models;

public interface IStoreRepository
{
    IQueryable<Product> Products { get; }
}