// CHAPTER 22 : Thread Synchronization

namespace Rozdzial22_2
{
    public class Program
    {
        readonly static object _Sync = new object();
        const int _Total = int.MaxValue;
        static long _Count = 0;
        public async static Task Main()
        {
            #region Synchronizing with a lock keyword
            Task task = Task.Run(() => Decrement());

            for (int i = 0; i < _Total; i++)
            {
                lock (_Sync)
                { _Count++; }
            }
            #endregion

            await task;
            Console.WriteLine($"Count = {_Count}");
        }

        static void Decrement()
        {
            for (int i = 0; i < _Total; i++)
            {
                lock (_Sync)
                {
                    _Count--;
                }
            }
        }


    }
}