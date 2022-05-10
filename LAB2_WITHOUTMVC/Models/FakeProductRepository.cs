namespace LAB2_WITHOUTMVC.Models
{
    public class FakeProductRepository : IProductRepository
    {
        public IQueryable<Product> Products => _products.AsQueryable();

        private List<Product> _products = new List<Product>()
        {
            new Product
            {
                Name = "Kajak",
                Description = "Łódka przeznaczona dla jednej osoby",
                Category = "Sporty wodne",
                Price = 275
            },
            new Product
            {
                Name = "Kamizelka ratunkowa",
                Description = "Chroni i dodaje uroku",
                Category = "Sporty wodne",
                Price = 48.95m
            }
        };
    }
}
