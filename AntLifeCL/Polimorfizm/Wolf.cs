using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntLifeCL.Polimorfizm
{
    public class Wolf : Animal, IPet
    {
        public override void Eat()
        {
            throw new NotImplementedException();
        }

        public void GiveName()
        {
            throw new NotImplementedException();
        }
    }
}
