using System;

namespace Prostokaty
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Rectangle rect1 = new Rectangle(4, 4, 0, 0);
            Console.WriteLine(rect1.ToString());

            Rectangle rect2 = new Rectangle(0, 0, 4, 4);
            Console.WriteLine(rect2.ToString());
            Console.ReadKey();
        }
    }
}