// CHAPTER 20 - Programming the Task-Based Asynchronous Pattern
using System.Net;
using System.Runtime.ExceptionServices;

namespace Rozdzial20_1
{
    internal class Program
    {
        public const string DefaultUrl = "https://IntelliTect.com";
        static void Main(string[] args)
        {
            #region Synchronous Web Request
            if (args.Length == 0)
            {
                Console.WriteLine("ERROR: No findText argument specified.");
                return;
            }
            string findText = args[0];

            string url = DefaultUrl;
            if (args.Length > 1)
            {
                url = args[1];
            }

            Console.Write($"Searching for '{findText}' at URL '{url}'.\n");

            Console.WriteLine("Downloading...");

            using WebClient webClient = new();
            byte[] downloadData = webClient.DownloadData(url);

            Console.Write("Searching...");
            int textOccurrenceCount = CountOccurrences(downloadData, findText);

            Console.WriteLine(@$"{Environment.NewLine}'{findText}' appears {textOccurrenceCount} times at URL '{url}'.");
            #endregion

            #region Asynchronous Invoking a High-Latency operation using the TPL

            Console.WriteLine();

            Console.Write($"Searching for '{findText}' at URL '{url}'.\n");

            Console.WriteLine("Downloading...");
            Console.Write("Searching");

            using WebClient webClientAsync = new();
            Task task = webClient.DownloadDataTaskAsync(url).ContinueWith(antecedent =>
            {
                byte[] downloadData = antecedent.Result;
                return CountOccurrencesAsync(downloadData, findText);
            })
                .Unwrap()
                .ContinueWith(antecedent =>
                {
                    int textOccurrenceCount = antecedent.Result;
                    Console.WriteLine($@"{Environment.NewLine}'{findText}' appears {textOccurrenceCount} times at URL '{url}'.");
                });
            try
            {
                while (!task.Wait(100))
                {
                    Console.Write(".");
                }
            }
            catch (AggregateException exception)
            {
                exception = exception.Flatten();
                try
                {
                    exception.Handle(innerException =>
                    {
                        ExceptionDispatchInfo.Capture(innerException).Throw();
                        return true;
                    });
                }
                catch (WebException)
                {

                }
                catch (IOException)
                {

                }
                catch (NotSupportedException)
                {

                }
            }
            #endregion
        }

        #region Synchronous Web Request (method)
        private static int CountOccurrences(byte[] downloadData, string findText)
        {
            int textOccurrenceCount = 0;

            using MemoryStream stream = new MemoryStream(downloadData);
            using StreamReader reader = new StreamReader(stream);

            int findIndex = 0;
            int length = 0;
            do
            {
                char[] data = new char[reader.BaseStream.Length];
                length = reader.Read(data);

                for (int i = 0; i < length; i++)
                {
                    if (findText[findIndex++] == data[i])
                    {
                        if (findIndex == findText.Length)
                        {
                            // text was found
                            textOccurrenceCount++;
                            findIndex = 0;
                        }
                    }
                    else
                    {
                        findIndex = 0;
                    }
                }
            }
            while (length != 0);

            return textOccurrenceCount;
        }
        #endregion

        #region Asynchronous Invoking a High-Latency operation using the TPL
        private static Task<int> CountOccurrencesAsync(byte[] downloadData, string findText)
        {
            return Task.Run<int>(() =>
            {
                int textOccurrenceCount = 0;

                using MemoryStream stream = new MemoryStream(downloadData);
                using StreamReader reader = new StreamReader(stream);

                int findIndex = 0;
                int length = 0;
                do
                {
                    char[] data = new char[reader.BaseStream.Length];
                    length = reader.Read(data);

                    for (int i = 0; i < length; i++)
                    {
                        if (findText[findIndex++] == data[i])
                        {
                            if (findIndex == findText.Length)
                            {
                                // text was found
                                textOccurrenceCount++;
                                findIndex = 0;
                            }
                        }
                        else
                        {
                            findIndex = 0;
                        }
                    }
                }
                while (length != 0);

                return textOccurrenceCount;
            });
        }
        #endregion
    }
}