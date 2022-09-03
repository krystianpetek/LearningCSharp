using System;

namespace ConsoleApp5_tryParse
{
    class Program
    {
        static void Main(string[] args)
        {
            string value = "102";
            int result = 0;
            if (int.TryParse(value, out result))
            {
                Console.WriteLine($"Measurement: {result}");
            }
            else
            {
                Console.WriteLine("Unable to report the measurement.");
            }
            Console.WriteLine($"Measurement (/w offset): {50 + result}");
            Console.WriteLine();
            string value2 = "bad";
            int result2 = 0;
            if (int.TryParse(value2, out result2))
            {
                Console.WriteLine($"Measurement: {result2}");
            }
            else
            {
                Console.WriteLine("Unable to report the measurement.");
            }
            if(result2 > 0)
            Console.WriteLine($"Measurement (/w offset): {50 + result}");


        }
    }
}
