using ContosoPizzaAPI_NET6_0.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizzaAPI_NET6_0.Data
{
    public class PromotionsContext : DbContext
    {
        public PromotionsContext(DbContextOptions<PromotionsContext> options) : base(options)
        {

        }
        public DbSet<Coupon> Coupons => Set<Coupon>();

    }
}
