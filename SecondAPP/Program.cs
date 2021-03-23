using System;

namespace SecondAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = 12;
            int secondNumber = 7;
            Console.WriteLine(firstNumber + secondNumber);
            string firstName = "Bob";
            int widgetsSold = 7;
            Console.WriteLine(firstName + " sold " + widgetsSold + 7 + " widgets.");
            Console.WriteLine(firstName + " sold " + (widgetsSold + 7) + " widgets.");

            int sum = 7 + 5;
            int difference = 7 - 5;
            int product = 7 * 5;
            int quotient = 7 / 5;

            Console.WriteLine("Sum: " + sum);
            Console.WriteLine("Difference: " + difference);
            Console.WriteLine("Product: " + product);
            Console.WriteLine("Quotient " + quotient);

            decimal decimalQuotient = 7.0m / 5;
            Console.WriteLine("Decimal quotient: " + decimalQuotient);

            int first = 7;
            int second = 5;
            decimal quotientTwo = (decimal)first / (decimal)second; // rzutowanie
            Console.WriteLine("Quotient two: "+quotientTwo);

            Console.WriteLine("Modulus of 200 / 5 : " + (200 % 5));
            Console.WriteLine("Modulus of 7 / 5 : " + (7 % 5));

            //PEMDAS (in maths!!)
            //P - parentheses (nawias) / E - exponents(potega) / M - multiplication / D - division / A - addition / S - subtraction

            int value1 = 3 + 4 * 5;
            int value2 = (3 + 4) * 5;
            Console.WriteLine("First Multiplication: " + value1);
            Console.WriteLine("First Parentheses :" + value2);

            int value = 1;
            Console.WriteLine("\nPrimary value is: " + value);
            value = value + 1;
            Console.WriteLine("First increment: " + value);
            value += 1;
            Console.WriteLine("Second increment: " + value);
            value++;
            Console.WriteLine("Third increment: " + value);
            value = value - 1;
            Console.WriteLine("First decrement: " + value);
            value -= 1;
            Console.WriteLine("Second decrement: " + value);
            value--;
            Console.WriteLine("Third decrement: " + value);
            Console.WriteLine("Last value is: " + value);

            //increment, decrement
            int valueL = 1;
            valueL++;
            Console.WriteLine("First: " + valueL);
            Console.WriteLine("Second: " + valueL++);
            Console.WriteLine("Third: " + valueL);
            Console.WriteLine("Fourth: " + (++valueL));

            int fahrenheit = 94;
            decimal oblicz = (fahrenheit - 32m) * 5m / 9m;
            Console.WriteLine($"The temperature is {oblicz} Celcius");

            Random dice = new Random();
            int roll = dice.Next(1, 7);
            Console.WriteLine($"Wylosowana liczba to: {roll}");

            int number = 7;
            string text = "seven";
            Console.WriteLine(number);
            Console.WriteLine();
            Console.WriteLine(text);

            int roll1 = dice.Next();
            int roll2 = dice.Next(101);
            int roll3 = dice.Next(50, 101);

            Console.WriteLine($"First roll: {roll1}");
            Console.WriteLine($"Second roll: {roll2}");
            Console.WriteLine($"Third roll: {roll3}");

            int firstValue = 500;
            int secondValue = 600;
            int largetValue = Math.Max(firstValue, secondValue);
            Console.WriteLine($"\nWiększa wartość z dwóch liczb to: {largetValue}");
        }
    }
}
