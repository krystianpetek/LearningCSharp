using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntLifeCL.Polimorfizm
{
    public class BazaMilitarna: BazaBody
    {
        public int WallResistance { get; set; }
        public override void CreateBase(string name, float longitude, float latitude)
        {
            base.CreateBase(name, longitude, latitude);

        }
        public virtual void CreateBase(string name, float Longitude, float Latitude, int WallResistance)
        {
            base.CreateBase(name, Longitude, Latitude);
            CreateDefense(WallResistance);
        }

        public override void CreateDefense(int val=0)
        {
            Debug.WriteLine("BM - defence value is set to: " + val);
        }
    }
}
