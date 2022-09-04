// CHAPTER 21: Iterating in Parallel

using System.Diagnostics;

namespace Rozdzial21_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10000; i++)
            {
                ;
            }
            Console.WriteLine();
            Parallel.For(0, 1000, i =>
            {
                ;
            });

            EncryptFiles(Directory.GetCurrentDirectory(), "*.*");
        }

        #region Parallel Loop Exception handling with AggregateException
        static void EncryptFiles(string directoryPath, string searchPattern)
        {
            IEnumerable<string> files = Directory.EnumerateFiles(directoryPath, searchPattern, SearchOption.AllDirectories);
            try
            {
                Parallel.ForEach(files, fileName =>
                {
                    Encrypt(fileName);
                });
            }
            catch (AggregateException exception)
            {
                Console.WriteLine("Catched exceptions from inside of method");
                Console.WriteLine($"ERROR: {exception.GetType().Name}");
                foreach (Exception item in exception.InnerExceptions)
                {
                    Console.WriteLine($"{item.GetType().Name}, {item.Message}");
                }
            }
        }

        private static void Encrypt(string fileName)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Canceling a Parallel Loop (parallel and asynchronous)
        static void ParallelEncryptFiles(string directgoryPath, string searchPattern)
        {
            string stars = "*".PadRight(Console.WindowWidth - 1, '*');

            IEnumerable<string> files = Directory.GetFiles(directgoryPath, searchPattern, SearchOption.AllDirectories);

            CancellationTokenSource cts = new();
            ParallelOptions parallelOptions = new() { CancellationToken = cts.Token, MaxDegreeOfParallelism = 5 };
            cts.Token.Register(() => Console.WriteLine("Cancelling..."));

            Console.WriteLine("Press any key to exit.");

            var task = Task.Run(() =>
            {
                try
                {
                    Parallel.ForEach(files, parallelOptions, (fileName, loopState) =>
                    {
                        Encrypt(fileName);
                    });
                }
                catch (OperationCanceledException) { }
            });

            Console.Read();
            cts.Cancel();
            Console.WriteLine(stars);
            task.Wait();
        }
        #endregion
    }

    class Cryptographer
    {

        private static string Encrypt(string fileName)
        {
            throw new NotImplementedException();
        }

        #region LINQ Select
        public List<string> Encrypt(IEnumerable<string> data)
        {
            return data.Select(item => Encrypt(item)).ToList();
        }
        #endregion

        #region Parallel LINQ Select
        public List<string> EncryptParallel(IEnumerable<string> data)
        {
            return data.AsParallel().Select(item => Encrypt(item)).ToList();
        }
        #endregion

        #region PLINQ sorting - standard query operators
        public void SortingParallel(IEnumerable<string> data)
        {
            OrderedParallelQuery<string> parallelGroups = data.AsParallel().OrderBy(item => item);
            Trace.Assert(data.Count() == parallelGroups.Sum(item => item.Count()));
        }
        #endregion

        #region PLINQ grouping - query expressions
        public void SortingParallelExpression(IEnumerable<string> data)
        {
            ParallelQuery<IGrouping<char, string>> parallelGroups = from text in data.AsParallel() orderby text group text by text[0];
            Trace.Assert(data.Count() == parallelGroups.Sum(item => item.Count()));
        }
        #endregion


    }
}