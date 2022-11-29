using SportsStore.Models;

namespace SportsStore.Data
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get; }
        Task SaveOrder(Order order);
    }
}
