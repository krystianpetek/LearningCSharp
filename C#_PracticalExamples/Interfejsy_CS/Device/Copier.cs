using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfejsy_CS.Device
{
    internal class Copier : Device, IScanner, IPrinter
    {
        void IScanner.Run() => Console.WriteLine("... scanning");
        void IPrinter.Run() => Console.WriteLine("... printing");
        public override void Run()
        {
            ((IScanner)this).Run();
            ((IPrinter)this).Run();
        }
    }
}
