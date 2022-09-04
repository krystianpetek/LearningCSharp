using System.Diagnostics;

namespace Rozdzial20_3
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string url = "https://intellitect.com/";
            if (args.Length > 0)
            {
                url = args[0];
            }
            Console.Write(url);

            // delegate with asynchronous lambda
            Func<string, Task> writeWebRequestSizeAsync = async (string webRequestUrl) =>
            {
                HttpClient client = new HttpClient();

                var response = await client.GetAsync(url);
                using StreamReader streamReader = new StreamReader(await response.Content.ReadAsStreamAsync());
                string text = await streamReader.ReadToEndAsync();

                Console.WriteLine(text);
            };
            // OR local function
            async Task WriteWebRequestSizeAsync(string webRequestUrl)
            {
                HttpClient client = new HttpClient();

                var response = await client.GetAsync(url);
                using StreamReader streamReader = new StreamReader(await response.Content.ReadAsStreamAsync());
                string text = await streamReader.ReadToEndAsync();

                Console.WriteLine(text);
            }

            Task task = writeWebRequestSizeAsync(url);
            while (!task.Wait(100))
            {
                Console.Write(".");
            }

            await WriteWebRequestSizeAsync(url);

            DisplayStatus("Before");
            Task taskA = Task.Run(() =>
            {
                DisplayStatus("Starting...");
            }).ContinueWith(a => DisplayStatus("Continuing A..."));
            Task taskB = taskA.ContinueWith(a => DisplayStatus("Continuing B"));
            Task taskC = taskA.ContinueWith(a => DisplayStatus("Continuing C"));
            Task.WaitAll(taskB, taskC);
            DisplayStatus("Finished");

            await RunProcessing();
        }

        private static async Task RunProcessing()
        {
            var task = Task.Run(async () =>
            {
                await Task.Delay(5000);
            });
            await Task.Delay(4000);
            Console.WriteLine(task.IsCompletedSuccessfully);
            await Task.Delay(1000);
            Console.WriteLine(task.IsCompletedSuccessfully);
        }

        #region custom asynch method with progress support
        public static Task<Process> RunProcessAsync(
            string fileName,
            string arguments = "",
            CancellationToken cancellationToken = default,
            IProgress<ProcessProgressEventArgs>? progress = null,
            object? objectState = null)
        {
            TaskCompletionSource<Process> taskCompletionSource = new();

            Process process = new Process()
            {
                StartInfo = new ProcessStartInfo(fileName)
                {
                    UseShellExecute = false,
                    Arguments = arguments,
                    RedirectStandardOutput = progress != null
                },
                EnableRaisingEvents = true
            };

            process.Exited += (sender, localEventArgs) =>
            {
                taskCompletionSource.SetResult(process);
            };

            if (progress != null)
            {
                process.OutputDataReceived += (sender, localEventArgs) =>
                {
                    // progress.Report(new ProcessProgressEventArgs(localEventArgs.Data, objectState));
                };
            }

            if (cancellationToken.IsCancellationRequested)
            {
                cancellationToken.ThrowIfCancellationRequested();
            }

            process.Start();

            if (progress != null)
            {
                process.BeginOutputReadLine();
            }

            cancellationToken.Register(() =>
            {
                process.CloseMainWindow();
                cancellationToken.ThrowIfCancellationRequested();
            });

            return taskCompletionSource.Task;
        }
        public class ProcessProgressEventArgs { }
        #endregion

        private static void DisplayStatus(string message)
        {
            string text = string.Format($@"{Thread.CurrentThread.ManagedThreadId}:  {message}");
            Console.WriteLine(text);
        }
    }
}