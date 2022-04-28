using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClose2
{
    internal class SquareHouse : Facility
    {
        public double Width { get; set; }   
        public override double CalculateSurface()
        {
            return Math.Pow(Width,2);
        }
    }
}
