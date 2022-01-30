using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypyGeneryczne
{
    public class Klient: IEncja
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
    }
}
