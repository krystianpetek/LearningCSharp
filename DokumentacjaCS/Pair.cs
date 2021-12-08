using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokumentacjaCS
{
    internal class Pair<TFirst, TSecond>
    {
        public TFirst First { get; set; }
        public TSecond Second { get; set; }
        public Pair(TFirst first, TSecond second) => (First, Second) = (first, second);
        public override string ToString() => $"{First}\n{Second}";
    }
}