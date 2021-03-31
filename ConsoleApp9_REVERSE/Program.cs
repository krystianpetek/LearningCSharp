using System;

namespace ConsoleApp9_REVERSE
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] pallets = { "B14", "A11", "B12", "A13" };
            Console.WriteLine("Sorted...");
            Array.Sort(pallets);
            foreach(var pallet in pallets)
            {
                Console.WriteLine($"-- {pallet}");
            }
            Console.WriteLine("");
            Console.WriteLine("Reversed...");
            Array.Reverse(pallets);
            foreach(var pallete in pallets)
            {
                Console.WriteLine($"-- {pallete}");
            }
        }
    }
}
