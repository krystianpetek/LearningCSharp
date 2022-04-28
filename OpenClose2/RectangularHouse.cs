using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClose2
{
    public class RectangularHouse : Facility
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public override double CalculateSurface()
        {
            return (2*Width + 2* Height);
        }
    }

}
