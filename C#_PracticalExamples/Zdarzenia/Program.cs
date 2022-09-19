using System;

namespace Zdarzenia
{
    internal partial class Program
    {
        public static void Main(string[] args)
        {
            TestowanieZdarzen testowanieZdarzen = new TestowanieZdarzen(5);
            testowanieZdarzen.SetValue(8);
            testowanieZdarzen.SetValue(16);
            Console.ReadKey();
        }
    }
}