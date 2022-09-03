using System;

namespace ConsoleApp7_FizzBuzz
{
	class Program
	{
		static void Main(string[] args)
		{
			for (int i = 1; i <= 100; i++)
			{
				if ((i % 5 == 0) && (i % 3 == 0))
				{
					Console.WriteLine($"{i} - FizzBuzz");
				}
				else if (i % 5 == 0)
				{
					Console.WriteLine($"{i} - Buzz");
				}
				else if (i % 3 == 0)
				{
					Console.WriteLine($"{i} - Fizz");
				}
				else
				{
					Console.WriteLine(i);
				}
			}
		}
	}
}
