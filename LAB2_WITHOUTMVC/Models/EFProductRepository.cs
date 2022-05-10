namespace LAB2_WITHOUTMVC.Models
{
    public class EFProductRepository : IProductRepository
    {
        public IQueryable<Product> Products => context.Products;
        private readonly AppDbContext context;

        public EFProductRepository(AppDbContext context)
        {
            this.context = context;
        }
    }
}
