using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    internal interface ICreator
    {
        public IProduct FactoryMethod();
    }
}
