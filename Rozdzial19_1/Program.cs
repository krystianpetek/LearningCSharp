using System.Diagnostics;

namespace Rozdzial19_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Invoking an Asynchronous Task (synchronous delegate)
            const int repetitions = 10000;

            Task task = Task.Run(() =>
            {
                for (int count = 0; count < repetitions; count++)
                    Console.Write("-");
            });
            for (int count = 0; count < repetitions; count++)
                Console.Write("+");

            task.Wait();
            #endregion

            #region Polling a Task<T>
            Task<string> taskPolling = Task.Run<string>(() => PiCalculator.Calculate(100));

            foreach (char busySymbol in Utility.BusySymbols())
            {
                if (taskPolling.IsCompleted)
                {
                    Console.WriteLine("\b");
                    break;
                }
                Console.WriteLine(busySymbol);
            }
            Console.WriteLine();

            Console.WriteLine(taskPolling.Result);

            Trace.Assert(taskPolling.IsCompleted);
            //829

            #endregion


        }

        #region PiCalculator
        public class PiCalculator
        {
            public static string Calculate(int digits = 100)
            {
                return "";
            }
        }
        #endregion
        #region Utility
        public class Utility
        {
            public static IEnumerable<char> BusySymbols()
            {
                string busySymbols = @"-\|/-\|/";
                int next = 0;
                while (true)
                {
                    yield return busySymbols[next];
                    next = (next + 1) % busySymbols.Length;
                    yield return '\b';
                }
            }
        }
        #endregion
    }
}