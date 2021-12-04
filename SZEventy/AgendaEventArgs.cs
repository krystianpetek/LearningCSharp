using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZEventy
{
    internal class AgendaEventArgs : EventArgs
    {
        public Agenda Agenda { get; set; }
    }
}
