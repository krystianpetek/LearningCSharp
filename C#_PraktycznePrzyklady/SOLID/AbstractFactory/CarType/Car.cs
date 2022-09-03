using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.CarType
{
    public abstract class Car
    {
        public virtual void Name()
        {
            Console.WriteLine(this.ToString());
        }
    }
}
