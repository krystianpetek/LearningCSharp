using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClose2
{
    internal class TriangleHouse : Facility
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public override double CalculateSurface()
        {
            return ((1 / 2) * Width * Height);
        }
    }
}
