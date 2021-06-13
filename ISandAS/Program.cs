using System;

namespace ISandAS
{
    sealed class Rectangle
    {
        public double Length { get; set; }
        public double Width { get; set; }
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
        public double GetArea()
        {
            return Length * Width;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Object o = new Rectangle(10, 20);

            if(o is Rectangle)
            {
                Rectangle r = (Rectangle)o;
            }

            Rectangle rz = o as Rectangle;
            if (rz != null)
            {
                Console.WriteLine("nie udało się");
            }
        }
    }
}
