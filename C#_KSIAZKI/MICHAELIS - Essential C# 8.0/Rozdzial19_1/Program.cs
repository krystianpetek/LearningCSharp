using System.Diagnostics;

namespace Rozdzial19_1
{
    internal class Program
    {
        public static Stopwatch _Clock = new();
        public async static Task Main(string[] args)
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

            await task;
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
            #endregion

            #region Calling Task.ContinueWith()
            Console.WriteLine("Before");
            Task taskA = Task.Run(
                () => Console.WriteLine("Starting...")).ContinueWith(antecedent => Console.WriteLine("Continuing A..."));

            Task taskB = taskA.ContinueWith(x => /* dont working */Task.Delay(10000)).ContinueWith(antecedent => Console.WriteLine("Continuing B..."));

            Task taskC = taskA.ContinueWith(antecedent => Console.WriteLine("Continuing C..."));

            Task.WaitAll(taskB, taskC);

            Console.WriteLine("Finished!");

            #endregion

            #region Registering for Notifications of Task Behavior with ContinueWith()
            Task<string> taskR1 = Task.Run<string>(() => PiCalculator.Calculate(10));

            Task faultedTaskR1 = taskR1.ContinueWith(antecedentTask =>
            {
                Trace.Assert(antecedentTask.IsFaulted);
                Console.WriteLine("Task State: Faulted");
            },
            TaskContinuationOptions.OnlyOnFaulted);

            Task canceledTaskR1 = taskR1.ContinueWith(antecedentTask =>
            {
                Trace.Assert(antecedentTask.IsCanceled);
                Console.WriteLine("Task State: Canceled");
            },
            TaskContinuationOptions.OnlyOnCanceled);

            Task completedTaskR1 = taskR1.ContinueWith(antecedentTask =>
            {
                Trace.Assert(antecedentTask.IsCompleted);
                Console.WriteLine("Task State: Completed");
            },
            TaskContinuationOptions.OnlyOnRanToCompletion);

            completedTaskR1.Wait();
            #endregion

            #region Handling a task's unhandled exception
            Task taskHandling = Task.Run(() =>
            {
                throw new InvalidOperationException();
            });

            try
            {
                taskHandling.Wait();
            }
            catch (AggregateException exception)
            {
                exception.Handle(eachException =>
                {
                    Console.WriteLine($"ERROR: {eachException.Message}");
                    return true;
                });
            }
            #endregion

            #region Registering for unhandled exception (in other thread)
            try
            {
                _Clock.Start();
                AppDomain.CurrentDomain.UnhandledException += (s, e) =>
                {
                    Message("Event handler starting");
                    Delay(4000);
                };

                Thread thread = new Thread(() =>
                {
                    Message("Throwing exception");
                    throw new Exception();
                });
                thread.Start();
                Delay(2000);
            }
            finally
            {
                Message("Finally block running.");
            }

            static void Delay(int i)
            {
                Message($"Sleeping for {i} ms");
                Thread.Sleep(i);
                Message("Awake");
            }

            static void Message(string text)
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}:{_Clock.ElapsedMilliseconds:F4}:{text}");
            }
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