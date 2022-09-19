using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypyGeneryczne
{
    public class PaginacjaRezultatow<T>
    {
        public int RezultatOd { get; set; }
        public int RezultatDo { get; set; }
        public int CalkowitaLiczbaStron { get; set; }
        public int CalkowitaLiczbaRezultatow { get; set; }
        public List<T> Rezultat { get; set; }
    }
}
