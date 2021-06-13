using System;

namespace _10._STRUCT
{
    public struct Point
    {
        public double X, Y;
    }
    class Rectangle
    {
        public double Length { get; set; }
        public double Width { get; set; }
    
    }
    class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point();
            p1.X = 10;
            p1.Y = 20;
            Point p2 = p1;
            p2.X = 100;
            Console.WriteLine($"p1.X = {p1.X}");

            Rectangle rect1 = new Rectangle
            {
                Length = 10,
                Width = 20
            };
            Rectangle rect2 = rect1;
            rect2.Length = 100.0;
            Console.WriteLine($"rect1.Length = {rect1.Length}");
        }
    }
}
