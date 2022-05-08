using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_12._05
{
    public class ProductsCollection : ObservableCollection<Produkt>
    {
        public ProductsCollection()
        {
            Add(new Produkt("01-11", "ołówek", 8, "Katowice 1"));
            Add(new Produkt("PW-20", "pióro wieczne", 75, "Katowice 2"));
            Add(new Produkt("DZ-10", "długopis żelowy", 1121, "Katowice 1"));
            Add(new Produkt("DZ-12", "długopis kulowy", 280, "Katowice 2"));
        }
    }
}
