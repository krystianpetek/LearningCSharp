using System;

namespace Rozdzial2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(42);
            Console.WriteLine(1.6180339887498955343424335F); // FLOAT
            Console.WriteLine(1.6180339887498955343424335D); // DOUBLE
            Console.WriteLine(1.6180339887498955343424335M); // DECIMAL
            Console.WriteLine(9_814_072_356); // SEPARATOR OD C# 7.0
            Console.WriteLine(6.023E23F); //liczba Avogarda
            Console.WriteLine(0x002A); // reprezentacja DECYMALNA liczby SZESTNASTKOWEJ 
            Console.WriteLine(0x002A); // reprezentacja DECYMALNA liczby SZESTNASTKOWEJ 
            Console.WriteLine(0B101010); // reprezentacja DECYMALNA liczby BINARNEJ
            
            Console.WriteLine($"0x{42:X}"); // reprezentacja SZESTNASTKOWA liczby DECYMALNEJ
            Console.WriteLine(string.Format("{0:R}", 1.618033988749895));
            //78
        }
    }
}
