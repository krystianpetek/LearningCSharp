using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfejsy_CS.LeftRight
{
    internal class Middle : ILeft, IRight
    {
        int ILeft.P { get { return 0; } }

        public int P() { return 0; }
    }
}
