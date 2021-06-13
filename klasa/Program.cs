using System;

namespace klasa
{
    class Obliczenia
    {
        private double length;
        private double width;
        public Obliczenia(double l, double w)
        {
            this.length = l;
            this.width = w;
        }
        
        public double mnozenie()
        {
            return length * width;
        }
        public double dzielenie()
        {
            return length / width;
        }
        public double dodawanie()
        {
            return length + width;
        }
        public double odejmowanie()
        {
            return length - width;
        }
    }

    class Program
    {
        delegate int ChangeNumber(int i);
        static int number = 5;
        public static int AddNumber(int i)
        {
            number += i;
            return number;
        }
        public static int MultiplyNumber(int i)
        {
            number *= i;
            return number;
        }
        public static int GetNumber()
        {
            return number;
        }
        static void Main(string[] args)
        {
            ChangeNumber cn1 = new ChangeNumber(AddNumber);
            ChangeNumber cn2 = new ChangeNumber(MultiplyNumber);

            cn1(5);
            Console.WriteLine("Wartość liczby: {0}",GetNumber());
            cn2(10);
            Console.WriteLine("Wartość liczby: {0}",GetNumber());


        //    var oblicz = new Obliczenia(5, 4);
        //    Console.WriteLine( oblicz.dodawanie());
        }
    }
}
