using System.Collections.Immutable;

namespace Rozdzial22_5
{
    internal class Program
    {
        #region using ThreadLocal<T> for Thread Local Storage
        static readonly ThreadLocal<double> _Count = new(() => 0.01134);
        public static double Count
        {
            get => _Count.Value;
            set => _Count.Value = value;
        }
        #endregion

        #region Using ThreadStaticAttribute for Thread Local Storage
        [ThreadStatic]
        static double _CountAttribute = 0.01145;
        public static double CountAttribute
        {
            get => _CountAttribute;
            set => _CountAttribute = value;
        }
        #endregion

        static void Decrement()
        {
            Count = -Count;
            for (double i = 0; i < short.MaxValue; i++)
            {
                CountAttribute--;
                Count--;
            }
            Console.WriteLine($"Decrement CountAttribute = {CountAttribute}");
            Console.WriteLine($"Decrement Count = {Count}");
        }

        public static void Main(string[] args)
        {
            Thread thread = new(Decrement);
            thread.Start();

            for (double i = 0; i < short.MaxValue; i++)
            {
                _CountAttribute++;
                Count++;
            }
            thread.Join();
            Console.WriteLine($"Main CountAttribute = {CountAttribute}");
            Console.WriteLine($"Main Count = {Count}");


            System.Collections.Immutable.IImmutableQueue<string> queue = ImmutableQueue.Create<string>();
            queue.Enqueue("");

            Console.WriteLine("Hello, World!");
        }
    }
}