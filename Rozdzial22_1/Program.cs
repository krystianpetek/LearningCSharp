// CHAPTER 22 : Thread Synchronization

namespace Rozdzial22_1
{
    public class Program
    {
        readonly static object _Sync = new object();
        const int _Total = int.MaxValue;
        static long _Count = 0;
        public async static Task Main()
        {
            //#region Unsynchronized Local Variable
            //int x = 0;
            //Parallel.For(0, int.MaxValue, i =>
            //{
            //    x++;
            //    x--;
            //});
            //Console.WriteLine("Count = {0}", x);
            //#endregion

            //#region Unsynchronized State
            //Task task = Task.Run(() => Decrement());

            //for (int i = 0; i < _Total; i++)
            //{
            //    _Count++;
            //}
            //await task;
            //Console.WriteLine("Count = {0}", _Count);
            //#endregion

            #region Synchronizing with a Monitor Explicitly
            Task taskMonitor = Task.Run(() =>
            {
                DecrementMonitor();
            });
            for (int i = 0; i < _Total; i++)
            {
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(_Sync, ref lockTaken);
                    _Count++;
                    Console.WriteLine(_Count);
                }
                finally
                {
                    if (lockTaken)
                    {
                        Monitor.Exit(_Sync);
                    }
                }
            }
            await taskMonitor;
            #endregion
        }

        private static void DecrementMonitor()
        {
            for (int i = 0; i < _Total; i++)
            {
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(_Sync, ref lockTaken);
                    _Count--;
                    Console.WriteLine(_Count);
                }
                finally
                {
                    if (lockTaken)
                    {
                        Monitor.Exit(_Sync);
                    }
                }
            }
        }

        static void Decrement()
        {
            for (int i = 0; i < _Total; i++)
            {
                _Count--;
            }
        }


    }
}