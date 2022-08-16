// CHAPTER 21: Iterating in Parallel

using System.Text;

namespace Rozdzial21_2
{
    public static class Program
    {
        public static List<string> ParallelEncrypt(List<string> data, CancellationToken ct)
        {
            int govener = 0;
            return data.AsParallel().WithCancellation(ct).Select(item =>
            {
                if (Interlocked.CompareExchange(ref govener, 0, 100) % 100 == 0)
                {
                    Console.Write(".");
                }
                Interlocked.Increment(ref govener);
                return Encrypt(item);
            }).ToList();
        }

        public static async Task Main()
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            List<string> data = new List<string>();

            using CancellationTokenSource cts = new();

            Task task = Task.Run(() =>
            {
                data = ParallelEncrypt(data, cts.Token);
            }, cts.Token);

            Console.WriteLine("Press any key to Exit.");
            Task<int> cancelTask = ConsoleReadAsync(cts.Token);

            try
            {
                Task.WaitAny(task, cancelTask);
                cts.Cancel();
                await task;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nCompleted successfully");
            }
            catch (OperationCanceledException taskCanceledException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nCancelled: {taskCanceledException.Message}");
            }
            finally
            {
                Console.ForegroundColor = originalColor;
            }
        }

        private static async Task<int> ConsoleReadAsync(CancellationToken cancellationToken = default)
        {
            return await Task.Run(async () =>
            {
                const int maxDelay = 1025;
                int delay = 0;
                while (!cancellationToken.IsCancellationRequested)
                {
                    if (Console.KeyAvailable)
                    {
                        return Console.Read();
                    }
                    else
                    {
                        await Task.Delay(delay, cancellationToken);
                        if (delay < maxDelay) delay *= 2 + 1;
                    }
                }
                cancellationToken.ThrowIfCancellationRequested();
                throw new InvalidOperationException("Previous line should throw preventing this from ever executing");
            }, cancellationToken);
        }
        private static string Encrypt(string item)
        {
            Cryptographer cryptographer = new();
            return Encoding.UTF8.GetString(cryptographer.Encrypt(item));
        }
    }

    internal class Cryptographer
    {
        public byte[] Encrypt(string item) { return new byte[0]; }
    }
}