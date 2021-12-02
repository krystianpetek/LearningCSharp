using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntLifeCL.Polimorfizm
{
    public abstract class BazaBody
    {
        public virtual string Name { get; set; }
        public virtual float Longitude { get; set; }
        public virtual float Latitude { get; set; }
        public virtual void CreateBase( string name , float longitude, float latitude)
        {
            Debug.WriteLine("BB - Name: " + name);
            Debug.WriteLine("BB - Localization: " + longitude + " | " + latitude);
        }
        public abstract void CreateDefense(int val);
    }
}
