using System;

namespace delegaty
{
    //public class Rectangle
    //{
    //    private double length;
    //    private double width;
    //    public Rectangle(double l, double w)
    //    {
    //        this.length = l;
    //        this.width = w;
    //    }
    //    public double GetArea()
    //    {
    //        return this.length * this.width;
    //    }
    //    static public void DisplayArea(Rectangle rect)
    //    {
    //        Console.WriteLine(rect.GetArea());
    //    }
    //    public double GetObw() => width + width + length + length;
    //    static public void DisplayPole(Rectangle rect)
    //    {
    //        Console.WriteLine(rect.GetObw());
    //    }
    //}

    public delegate double Function(double x, double y);
    public class Kalk
    {
        internal double X { get; }
        internal double Y { get; }
        public Kalk(double x, double y) => (X, Y) = (x, y);
        public double Dodaj(double x, double y) => (X + Y);
        public double Odejmij(double x, double y) => (X - Y);
        public double Pomnoz(double x, double y) => (X * Y);
        public double Podziel(double x, double y) => (X / Y);
        public double Modulo(double x, double y) => (X % Y);

        public static double Apply(Kalk a, Function b)
        {
            double result = b(a.X, a.Y);
            return result;
        }
    }
    class Program
    {
        //public delegate void RectangleHandler(Rectangle rect);
        //static void Main1(string[] args)
        //{
        //    RectangleHandler handler;
        //    handler = Rectangle.DisplayArea;

        //    var z = new Rectangle(7, 5);

        //    handler(z);
        //    handler += Rectangle.DisplayPole;

        //    handler(z);

        //}

        public static void Main(string[] args)
        {
            Kalk oblicz = new Kalk(66, 54);
            var x = Kalk.Apply(oblicz, oblicz.Dodaj);
            Console.WriteLine(x);
        }


    }
}



