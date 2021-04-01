using System;

namespace ConsoleApp17_zadanieCiagi
{
    class Program
    {
        static void Main(string[] args)
        {
            string customerName = "Mr. Jones";

            string currentProduct = "Magic Yield";
            int currentShares = 2975000;
            decimal currentReturn = 0.1275m;
            decimal currentProfit = 55000000.0m;

            string newProduct = "Glorious Future";
            decimal newReturn = 0.13125m;
            decimal newProfit = 63000000.0m;

            Console.WriteLine($"Dear {customerName},");
            Console.WriteLine($"As a customer of our {currentProduct} offering we are excited to yell you about a new financial product that would dramatically increase your return.\n");
            Console.WriteLine($"Currently, you own {currentShares:N2} shares at a return of {currentReturn:P2}.\n");
            Console.WriteLine($"Our new product, {newProduct} offers a return of {newReturn:P2}. Given your current volume, your potential profit would be {newProfit:C}.\n");

            Console.WriteLine("Here's a quick comparison:\n");

            string comparisonMessage = "";
            comparisonMessage += $"{currentProduct.PadRight(20)}{currentReturn:P2}   {currentProfit:C}.\n";
            comparisonMessage += $"{newProduct.PadRight(20)}{newReturn:P2}   {newProfit:C}.";

            Console.WriteLine(comparisonMessage);

            string comparisonMessage2 = "";
            comparisonMessage2 += "\n";
            comparisonMessage2 += currentProduct.PadRight(20);
            comparisonMessage2 += String.Format("{0:P}", currentReturn).PadRight(10);
            comparisonMessage2 += String.Format("{0:C}", currentProfit).PadRight(20);

            comparisonMessage2 += "\n";
            comparisonMessage2 += newProduct.PadRight(20);
            comparisonMessage2 += String.Format("{0:P}", newReturn).PadRight(10);
            comparisonMessage2 += String.Format("{0:C}", newProfit).PadRight(20);

            Console.WriteLine(comparisonMessage2);
        }
    }
}
