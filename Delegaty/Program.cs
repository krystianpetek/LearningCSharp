using System;
using System.Collections.Generic;
namespace Delegaty
{
    internal class Program
    {
        public delegate void Display(string value);

        static void Main(string[] args)
        {

            Display display = (string value) => Console.Write(value + " ");

            display("Test");

            var numbers = new int[] { 10, 30, 50 };
            DisplayNumbers(numbers,display);

            var countNumbers = Count(numbers, (int value) => value > 25);
            Console.WriteLine($"\ncountNumbers: {countNumbers}");

            var strings = new string[] { "Generic", "Delegate", "Test" };
            var countStrings = Count<string>(strings, (string value) => value.Length > 4);
            Console.WriteLine($"countStrings: {countStrings}");

        }


        static void DisplayNumbers(IEnumerable<int> numbers, Display display)
        {
            foreach(int number in numbers)
                display(number.ToString());
        }

        static int Count<T>(IEnumerable<T> elements, Predicate<T> predicate)
        {
            int count = 0;
            foreach(T element in elements)
            {
                if(predicate(element))
                {
                    count++;
                }
            }
            return count;
        }


        // wbudowane delegaty generyczne
        // 1. Action - void
        // 2. Func - zwracają silnie typowaną wartość
        // 3. Predicate - zwraca wartość bool a przyjmuje wartość typu T
    }
}
