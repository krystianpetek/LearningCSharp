using System;
using MyNewApp1; // !!

namespace ConsoleApp3_kontrolaZmiennaLogika
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag = true;
            int value = 0;
            if(flag)
            {
                value = 10;
                Console.WriteLine($"Kod wewnątrz bloku: {value}");
            }
            Console.WriteLine($"Kod na zewnątrz bloku: {value} ");
            
            string value2 = "Microsoft Learn";
            string reversedValue = Utility.Reverse(value2); // !
            Console.WriteLine($"Secret message: {reversedValue}");
        }
        /*
        static string Reverse(string message)
        {
            char[] letters = message.ToCharArray();
            Array.Reverse(letters);
            return new string(letters);
        }
        */
    }
    
}
namespace MyNewApp1 // !!
{
    class Utility // !
    {
        public static string Reverse(string message)
        {
            char[] letters = message.ToCharArray();
            Array.Reverse(letters);
            return new string(letters);
        }
    }
}