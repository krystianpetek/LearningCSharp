using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfejsy_CS.ExplicitImplicit
{
    internal class A : IA
    {
        public void M() => Console.WriteLine("Implementacja niejawna (implicit)");
        void IA.M() => Console.WriteLine("Implementacja jawna (explicit)");
    }
}