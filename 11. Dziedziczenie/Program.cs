using System;

namespace _11._Dziedziczenie
{
    abstract class Polygon
    {
        public double Length
        {
            get;
            protected set;
        }
        public double Width
        {
            get;
            protected set;
        }
        abstract public double GetArea();
    }
    sealed class Rectangle : Polygon
    {
        public Rectangle(double length, double width)
        {
            Length = length;
            Width = width;
        }
        public override string ToString()
        {
            return string.Format(
                $"Width: {Width}, Length: {Length}");
        }
        public override double GetArea()
        {
            return Length * Width;
        }
    }
    class Triangle: Polygon
    {
        public override double GetArea()
        {
            return this.Length;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var rect = new Rectangle(10, 20);
            Console.WriteLine($"{rect.Width}, {rect.Length}, {rect.GetArea()}");

            Console.WriteLine(rect.ToString());
        }
    }
}
