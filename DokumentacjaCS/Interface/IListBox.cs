using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokumentacjaCS.Interface
{
    internal interface IListBox: IControl
    {
        void SetItems(string[] items);
    }
}
