using System;

namespace Rozdzial11_1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public sealed class TextNumberParser 
    {
        public static int Parse(string textDigit)
        {
            string[] digitTexts = { "zero", "jeden", "dwa", "trzy", "cztery", "pięć", "sześć", "siedem", "osiem", "dziewięć" };
            int result = Array.IndexOf(digitTexts, textDigit ?? throw new ArgumentNullException(nameof(textDigit).ToLower()));
            if(result < 0)
            {
                throw new ArgumentException("Argument nie reprezentuje cyfry", nameof(textDigit));
            }
            return result;
        }
    }
}