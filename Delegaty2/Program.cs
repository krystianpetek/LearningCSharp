using System;

namespace Delegaty2
{
    class Obliczenia
    {
        public delegate void Operacje(Obliczenia O);
        private readonly int X;
        private readonly int Y;
        public Obliczenia(int x, int y)
        {
            X = x;
            Y = y;
        }
        public void Dodawanie()
        {
            Console.WriteLine(X + Y);
        }
        public void Odejmowanie()
        {
            Console.WriteLine(X - Y);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Obliczenia(5, 3);
            var aa = new Obliczenia.Operacje(a);
        }
    }
}
