using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypyCS
{
    internal class Ulamek
    {
        public int Licznik { get; private set; }
        private int mianownik;
        public int Mianownik {
            get => mianownik;
            private set 
            {
                if(value == 0) throw new DivideByZeroException();
                mianownik = value;
            }
        }
        public Ulamek(int licznik = 0,int mianownik = 1)
        {
            Licznik = licznik;
            Mianownik = mianownik;
        }
        public override string ToString() => $"{Licznik}/{Mianownik}";
        public static implicit operator Ulamek(int value) => new Ulamek(value,1);
        public static explicit operator int(Ulamek u) => u.Licznik / u.Mianownik;
    }
}
