using System.Runtime.CompilerServices;

namespace Rozdzial20_2
{
    public class Program
    {
        private static async ValueTask<byte[]> CompressAsync(byte[] buffer)
        {
            if (buffer.Length == 0)
            {
                return buffer;
            }

            using MemoryStream memoryStream = new();
            using System.IO.Compression.GZipStream gZipStream = new(memoryStream, System.IO.Compression.CompressionMode.Compress);

            await gZipStream.WriteAsync(buffer, 0, buffer.Length);

            return memoryStream.ToArray();
        }

        public async Task<int> DoStuffAsync()
        {
            await DoSomethingAsync();
            await DoSomethingElseAsync();
            return await GetAnIntegerAsync() + 1;
        }

        private Task<int> GetAnIntegerAsync()
        {
            throw new NotImplementedException();
        }

        private Task DoSomethingElseAsync()
        {
            throw new NotImplementedException();
        }

        private Task DoSomethingAsync()
        {
            throw new NotImplementedException();
        }

        #region Asynchronous Streams
        public static async Task Main(params string[] args)
        {
            string directoryPath = Directory.GetCurrentDirectory();
            const string searchPattern = "*";

            using Cryptographer cryptographer = new Cryptographer();

            IEnumerable<string> files = Directory.EnumerateFiles(directoryPath, searchPattern);

            using CancellationTokenSource cancellationTokenSource = new(1000 * 60); // more than 1 minute don't response

            await foreach ((string fileName, string encryptedFileName) in EncryptFilesAsync(files, cryptographer).Zip(files.ToAsyncEnumerable()).WithCancellation(cancellationTokenSource.Token))
            {
                Console.WriteLine($"{fileName}=>{encryptedFileName}");
            }
        }

        static public async IAsyncEnumerable<string> EncryptFilesAsync(IEnumerable<string> files, Cryptographer cryptographer, [EnumeratorCancellation] CancellationToken ct = default)
        {
            foreach (string fileName in files)
            {
                yield return await EncryptFileAsync(fileName, cryptographer);
                ct.ThrowIfCancellationRequested();
            }
        }

        private static async Task<string> EncryptFileAsync(string fileName, Cryptographer cryptographer)
        {
            string encryptedFileName = $"{fileName}".encrypt;
            await using FileStream outputFileStream = new(encryptedFileName, FileMode.Create);

            string data = await File.ReadAllTextAsync(fileName);
            await cryptographer.EncryptAsync(data, outputFileStream);
            return encryptedFileName;
        }
        #endregion
    }

    public class Cryptographer : IDisposable
    {

        public Cryptographer()
        {
        }
    }

    public class AsyncEncryptionCollection : IAsyncEnumerable<string?>
    {
        public IAsyncEnumerator<string?> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
        public static async void MAIN()
        {
            AsyncEncryptionCollection collection = new();

            await foreach (string fileName in collection)
            {
                Console.WriteLine(fileName);
            }
        }
    }

    #region Catching an exception from an async void method
    public class AsyncSynchronizationContext : SynchronizationContext
    {
        public Exception? Exception { get; set; }
        public ManualResetEventSlim ResetEvent { get; } = new();

        public override void Send(SendOrPostCallback d, object? state)
        {
            try
            {
                Console.WriteLine($@"Send notification invoked...(Thread ID: {Thread.CurrentThread.ManagedThreadId})");
                d(state);
            }
            catch (Exception exception)
            {
                Exception = exception;
#if !WithOutUsingResetEvent
                ResetEvent.Set();
#endif
            }
        }

        public override void Post(SendOrPostCallback d, object? state)
        {
            try
            {
                Console.WriteLine($@"Post notification invoked...(Thread ID: {Thread.CurrentThread.ManagedThreadId})");
                d(state);
            }
            catch (Exception exception)
            {
                Exception = exception;
#if !WithOutUsingResetEvent
                ResetEvent.Set();
#endif
            }
        }
    }
    public static class Programek
    {
        static bool EventTriggered { get; set; }
        public const string ExpectedExceptionMessage = "Expected Exception";
        public static async void Main()
        {
            SynchronizationContext? originalSynchronizationContext = SynchronizationContext.Current;
            try
            {
                //                AsyncSynchronizationContext synchronizationContext = new();
                //                SynchronizationContext.SetSynchronizationContext(synchronizationContext);

                //                await OnEvent(typeof(Programek), EventArgs.Empty));

                //#if !WithOutUsingResetEvent
                //                Task.Delay(1000).Wait();
                //#else
                //                synchronizationContext.ResetEvent.Wait();
                //#endif
                //                if(synchronizationContext.Exception != null)
                //                {
                //                    Console.WriteLine($@"Throwing expected exception...(Thread ID: {Thread}");
                //                }
            }
            catch (Exception exception)
            {
                ;
            }
        }
    }
    #endregion
}