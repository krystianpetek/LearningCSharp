using System;

namespace ConsoleApp14_formatowanieCiagow
{
    class Program
    {
        static void Main(string[] args)
        {
			string first = "Hello";
			string second = "World!";
			string result = string.Format("{0} {1}", first, second);
			Console.WriteLine(result);
			result = string.Format("{1} {0}", first, second);
			Console.WriteLine(result);
			result = string.Format("{0} {0} {0}!", first, second);
			Console.WriteLine(result);

			decimal price = 123.45m;
			int discount = 50;
			Console.WriteLine($"Price: {price:C} (Save: {discount:C})");

			decimal measurement = 123456.78912m;
			Console.WriteLine($"Measurement: {measurement:N} units");
			Console.WriteLine($"Measurement: {measurement:N4} units");

			decimal tax = .36785m;
			Console.WriteLine($"Tax rate: {tax:P2}");
		}
    }
}
