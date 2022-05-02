using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rekords
{
    internal class CurrencyClass
    {
        public int Value { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return $"{Name} {Value}";
        }
    }
    
}
