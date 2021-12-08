using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokumentacjaCS.Interface
{
    internal interface ITextBox : IControl
    {
        void SetText(string text);
    }
}
