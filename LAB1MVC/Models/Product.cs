namespace LAB1MVC.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public override string ToString()
        {
            return $"{ProductName}: {ProductDescription} - {ProductPrice}";
        }
    }
}
