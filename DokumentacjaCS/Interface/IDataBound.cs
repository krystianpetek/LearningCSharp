using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DokumentacjaCS.Interface
{
    internal interface IDataBound
    {
        void Bind(Binder b);
    }
}
