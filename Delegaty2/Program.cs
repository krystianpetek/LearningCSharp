using System;

namespace Delegaty2
{
    class Obliczenia
    {
        public delegate void Operacje(int x, int y);
        private readonly int X;
        private readonly int Y;
        public Obliczenia(int x, int y)
        {
            X = x;
            Y = y;
        }
        public void Dodawanie(int x,int y)
        {
            Console.WriteLine(x+ y);
        }
        public void Odejmowanie(int x, int y)
        {
            Console.WriteLine(X - Y);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Obliczenia(5, 3);
            var aa = new Obliczenia.Operacje(a.Dodawanie);
            Console.WriteLine(aa);
        }
    }
}
