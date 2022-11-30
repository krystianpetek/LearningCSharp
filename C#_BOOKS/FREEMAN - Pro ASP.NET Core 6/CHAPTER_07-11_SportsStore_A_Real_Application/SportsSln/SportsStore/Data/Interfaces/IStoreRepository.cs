using SportsStore.Models;

namespace SportsStore.Data.Interface;

public interface IStoreRepository
{
    IQueryable<Product> Products { get; }
}