using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypyGeneryczne
{
    public static class Narzedzia
    {
        public static void ZamianaRefow<GEN>( ref GEN pierwszy, ref GEN drugi)
        {
            GEN temp = pierwszy;
            pierwszy = drugi;
            drugi = temp;
        }
    }
}
