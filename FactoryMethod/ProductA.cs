using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod;

internal class ProductA : IBaseProduct
{
    public void WykonajDzialanie()
    {
        Console.WriteLine("Produkt A");
    }
}
