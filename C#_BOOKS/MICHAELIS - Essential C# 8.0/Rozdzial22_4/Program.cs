namespace Rozdzial22_4
{
    internal class Program
    {
        static ManualResetEventSlim _mainSignaledResetEvent;
        static ManualResetEventSlim _doWorkSignaledResetEvent;

        public static void DoWork()
        {
            Console.WriteLine("DO work started...");
            _doWorkSignaledResetEvent.Set();
            _mainSignaledResetEvent.Wait();
            Console.WriteLine("DO work ending....");
        }

        static void Main(string[] args)
        {
            using (_mainSignaledResetEvent = new())
            using (_doWorkSignaledResetEvent = new())
            {

                Console.WriteLine("App start");
                Console.WriteLine("Task start");
                Task task = Task.Run(() => DoWork());
                _doWorkSignaledResetEvent.Wait();
                Console.WriteLine("Waiting while thread executes...");
                _mainSignaledResetEvent.Set();
                task.Wait();
                Console.WriteLine("Completed");
            }
        }
    }
}