namespace LAB2_WITHOUTMVC.Models
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
    }
}
