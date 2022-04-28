using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversion
{
    internal interface IDoAnAction
    {
        public void DoAction(string message);
    }
}
