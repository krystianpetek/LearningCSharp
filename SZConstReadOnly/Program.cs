using System;

namespace SZConstReadOnly
{
    internal class Program
    {
        public const int thisIsConst = 10;
        public static readonly double thisIsReadOnly = 99.66;
        static Program()
        {
            thisIsReadOnly = 10.11;
        } 
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
