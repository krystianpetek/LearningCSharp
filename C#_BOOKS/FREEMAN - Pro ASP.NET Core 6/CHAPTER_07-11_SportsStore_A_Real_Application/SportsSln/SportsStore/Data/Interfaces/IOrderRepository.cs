using SportsStore.Models;

namespace SportsStore.Data.Interface
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get; }
        Task SaveOrder(Order order);
    }
}
