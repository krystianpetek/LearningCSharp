namespace Rozdzial22_6
{
    internal class Program
    {
        private static async Task TickAsync(CancellationToken token)
        {
            for (int minute = 0; minute < 25; minute++)
            {
                //DisplayMinuteTicker(minute);
                for (int second = 0; second < 60; second++)
                {
                    await Task.Delay(1000);
                    if (token.IsCancellationRequested) break;
                    DisplaySecondTicker(minute, second);
                }
                if (token.IsCancellationRequested) break;
            }
        }

        private static void DisplayMinuteTicker(int minute)
        {
            Console.Write($"{minute}:");
            Console.WriteLine();
            Console.Clear();
        }

        private static void DisplaySecondTicker(int minute, int second)
        {
            Console.WriteLine($"{minute}:{second}");
        }

        static async Task Main(string[] args)
        {
            await TickAsync(new CancellationToken());
        }
        // Coverage included the lock keyword, which leverages
        //System.Threading.Monitor under the covers.Other synchronization classes include
        //System.Threading.Interlocked, System.Threading.Mutext, System.Threading.WaitHandle,
        //reset events, semaphores, and the concurrent collection classes.
    }
}