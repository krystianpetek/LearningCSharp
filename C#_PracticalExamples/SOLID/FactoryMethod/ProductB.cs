using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod;

internal class ProductB : IProduct
{
    public void WykonajDzialanie()
    {
        Console.WriteLine("Produkt B");
    }
}