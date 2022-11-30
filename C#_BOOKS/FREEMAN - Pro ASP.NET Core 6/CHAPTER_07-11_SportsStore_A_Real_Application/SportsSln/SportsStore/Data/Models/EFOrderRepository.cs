using Microsoft.EntityFrameworkCore;
using SportsStore.Data.Interface;
using SportsStore.Models;

namespace SportsStore.Data.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private readonly StoreDbContext _storeDbContext;

        public EFOrderRepository(StoreDbContext storeDbContext)
        {
            _storeDbContext = storeDbContext;
        }

        public IQueryable<Order> Orders => _storeDbContext.Orders
            .Include(order => order.Lines)
            .ThenInclude(cartLine => cartLine.Product);

        public Task SaveOrder(Order order)
        {
            _storeDbContext.AttachRange(order.Lines.Select(cartLine => cartLine.Product));
            if (order.OrderId == 0)
            {
                _storeDbContext.Orders.Add(order);
            }
            _storeDbContext.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
