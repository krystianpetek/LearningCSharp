using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibility
{
    internal class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public uint Quantity { get; set; }
        public decimal Price { get; set; }
        public IList<Product> Products { get; set; }
        public Product()
        {
            Products = new List<Product>();
        }
        public void AddProduct(Product _prod)
        {
            Products.Add(_prod);
        }
        public void RemoveProduct(Product _prod)
        {
            Products.Remove(_prod);
        }
        public Product FindByID(int id)
        {
            return Products.SingleOrDefault(p => p.ID == id);
        }
    }
}
