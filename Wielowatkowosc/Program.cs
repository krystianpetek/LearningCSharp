using System;
using System.Threading;

namespace Wielowatkowosc
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Thread th = Thread.CurrentThread;
            th.Name = "GłównyWątek";
            Console.WriteLine($"To jest {th.Name}");
            Console.WriteLine($"To jest {th.IsBackground}");

            ThreadStart ts = new ThreadStart(CallToChildThread);
            Console.WriteLine("Tworzenie wątku pochodnego");
            Thread pochodnyWatek = new Thread(ts);

            pochodnyWatek.Start();
            Console.ReadKey();
        }

        public static void CallToChildThread()
        {
            Console.WriteLine("Wątek pochodny wystartował");
            int sleepFor = 5000;
            Console.WriteLine($"Wątek zostanie zatrzymany na {sleepFor / 1000} sekund.");
            Thread.Sleep(sleepFor);
            Console.WriteLine("Wznowienie wykonywania wątku.");
        }
    }
}