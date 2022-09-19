// CHAPTER 22 : Thread Synchronization

using System.Reflection;

namespace Rozdzial22_3
{
    public class Program
    {
        private static object? _Data;
        static object? previous;
        public static int _count = 0;
        static void Initialize(object newValue)
        {
            Interlocked.CompareExchange(ref _Data, newValue, null);
            previous = Interlocked.Exchange(ref _Data, "12a3");
            Interlocked.Increment(ref _count);
            Interlocked.Add(ref _count, 68);
        }
        public static void Main()
        {
            #region Using the System.Threading.Interlocked class
            Initialize("123");
            Console.WriteLine(_Data);
            Console.WriteLine(previous);
            Console.WriteLine(_count);
            #endregion

            #region Event Notification with Multiple Threads, thread safe event notification
            //TemperatureChangedHandler localOnChange = OnTemperatureChanged;
            //if (localOnChanged != null)
            //{
            //    // Call subscribers
            //    localOnChanged(
            //    this, new TemperatureEventArgs(value));
            //}


            // IN C# 6.0
            //OnTemperatureChanged?.Invoke(this, new TemperatureEventArgs(value)); // atomic operation
            #endregion

            #region Using the System.Threading.Mutex
            string mutexName = Assembly.GetEntryAssembly()!.FullName!;

            using Mutex mutex = new Mutex(false, mutexName, out bool firstApplicationInstance);

            if (!firstApplicationInstance)
            {
                Console.WriteLine($"This application is already running.");
            }
            else
            {
                Console.WriteLine("ENTER to shut down");
                Console.ReadLine();
            }
            #endregion
        }

    }
}