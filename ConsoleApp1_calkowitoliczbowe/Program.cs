using System;

namespace ConsoleApp1_calkowitoliczbowe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("typy całkowite ze znakiem:");
            Console.WriteLine($"sbyte  : {sbyte.MinValue} to {sbyte.MaxValue}");
            Console.WriteLine($"short  : {short.MinValue} to {short.MaxValue}");
            Console.WriteLine($"int  : {int.MinValue} to {int.MaxValue}");
            Console.WriteLine($"long  : {long.MinValue} to {long.MaxValue}");

            Console.WriteLine("typy całkowite bez znaku:");
            Console.WriteLine($"byte  : {byte.MinValue} to {byte.MaxValue}");
            Console.WriteLine($"ushort  : {ushort.MinValue} to {ushort.MaxValue}");
            Console.WriteLine($"uint  : {uint.MinValue} to {uint.MaxValue}");
            Console.WriteLine($"ulong  : {ulong.MinValue} to {ulong.MaxValue}");
        }
    }
}
