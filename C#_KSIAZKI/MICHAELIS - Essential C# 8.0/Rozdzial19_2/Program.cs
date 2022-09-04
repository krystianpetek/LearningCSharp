namespace Rozdzial19_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Canceling a Task Using CancellationToken
            string stars = "*".PadRight(Console.WindowWidth - 1, '*');
            Console.WriteLine("Push ENTER to exit.");

            CancellationTokenSource cancellationTokenSource = new();
            Task task = Task.Run(
                () =>
                {
                    WritePi(cancellationTokenSource.Token);
                },
                cancellationTokenSource.Token);

            Console.ReadLine();
            cancellationTokenSource.Cancel();
            Console.WriteLine(stars);
            task.Wait();
            Console.WriteLine();
            #endregion
        }
        #region Using Task.Factory.StartNew(), rather use Task.Run
        public Task<string> CalculatePiAsync(int digits)
        {
            return Task.Factory.StartNew(() => PiCalculator.Calculate(digits, 0), TaskCreationOptions.LongRunning);
        }
        #endregion

        #region Canceling a Task Using CancellationToken
        private static void WritePi(CancellationToken cancellationToken)
        {
            const int batchSize = 1;
            string piSection = string.Empty;
            int i = 0;

            while (!cancellationToken.IsCancellationRequested || i == int.MaxValue)
            {
                piSection = PiCalculator.Calculate(batchSize, (i++) * batchSize);
                Console.Write(piSection);
            }
        }
        public class PiCalculator
        {
            public static string Calculate(int digits, int startingAt)
            {
                return "!";
            } // UNDONE
        }
        #endregion

    }
}