using System;

namespace ConsoleApp2_zmiennoprzecinkowe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Typy zmiennoprzecinkowe:");
            Console.WriteLine($"float  : {float.MinValue} to {float.MaxValue} z dokładnością 6-9 cyfr");
            Console.WriteLine($"double  : {double.MinValue} to {double.MaxValue} z dokładnością 15-17 cyfr");
            Console.WriteLine($"decimal  : {decimal.MinValue} to {decimal.MaxValue} z dokładnością 28-29 cyfr");
        }
    }
}
