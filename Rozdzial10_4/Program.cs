using System;
using System.IO;
using System.Linq;

namespace Rozdzial10_4
{
    public class TemporaryFileStream : IDisposable
    {
        public TemporaryFileStream(string fileName)
        {
            File = new FileInfo(fileName);
            Stream = new FileStream(File.FullName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        }

        public FileInfo File { get; private set; }
        public FileStream Stream { get; private set; }

        public TemporaryFileStream() : this(Path.GetTempFileName())
        {
        }

        ~TemporaryFileStream()
        {
            Dispose(false);
        }

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            // wlaczenie wywolan finalizatora
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                Stream?.Close();
            }
            try
            {
                File?.Delete();
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex);
            }
            Stream = null;
            File = null;
        }
    }

    public class Program
    {
        public static void Search()
        {
            TemporaryFileStream fileStream = new TemporaryFileStream();
            fileStream.Dispose();

            using (TemporaryFileStream fileStream2 = new TemporaryFileStream(), fileStream3 = new TemporaryFileStream())
            {
                // korzstanie z obiektu temporaryfilestream
            }
            // od c# 8.0, using to składniowy skrót try-finally, aby uzyc using musi byc implementacja IDisposable
            using TemporaryFileStream fileStream1 = new TemporaryFileStream();
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Main: Starting...");
            DoStuff();
            if (args.Any(arg => arg.ToLower() == "-gc"))
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            Console.WriteLine("Main: Kończenie pracy...");
        }

        public static void DoStuff()
        {
            Console.WriteLine("DoStuff: Rozpoczynanie pracy...");
            SampleUnmanagedResource sampleUnmanagedResource = null;
            try
            {
                sampleUnmanagedResource = new SampleUnmanagedResource();
            }
            finally
            {
                if (Environment.GetCommandLineArgs().Any(
                    arg => arg.ToLower() == "-dispose"))
                {
                    sampleUnmanagedResource?.Dispose();
                }
                Console.WriteLine("DoStuff: Kończenie pracy...");
            }
        }

        public class SampleUnmanagedResource : IDisposable
        {
            public SampleUnmanagedResource(string fileName)
            {
                Console.WriteLine("SampleUnmanagedResource: Rozpoczynanie pracy...", $"{nameof(SampleUnmanagedResource)}.ctor");
                Console.WriteLine("SampleUnmanagedResource: Tworzenie zasobów zarządzanych...", $"{nameof(SampleUnmanagedResource)}.ctor");
                Console.WriteLine("SampleUnmanagedResource: Tworzenie zasobów niezarządzanych...", $"{nameof(SampleUnmanagedResource)}.ctor");

                var weakReferenceToSelf = new WeakReference<IDisposable>(this);
                ProcessExitHandler = (_, __) =>
                {
                    Console.WriteLine("ProcessExitHandler: Rozpoczynanie pracy...", ProcessExitHandler);
                    if (weakReferenceToSelf.TryGetTarget(out IDisposable? self))
                    {
                        self.Dispose();
                    }
                    Console.WriteLine("ProcessExitHandler: Kończenie pracy...", ProcessExitHandler);
                };
                AppDomain.CurrentDomain.ProcessExit += ProcessExitHandler;
                Console.WriteLine("SampleUnmanagedResource: Kończenie pracy...", $"{nameof(SampleUnmanagedResource)}.ctor");
            }

            // Zapisywanie delegata do obsługi zdarzenia ProcessExit, dzięki czemu można
            // go usunąć, jeśli metoda Dispose() lub Finalize() została już wywołana.
            public EventHandler ProcessExitHandler { get; }

            public SampleUnmanagedResource() : this(Path.GetTempFileName())
            {
            }

            ~SampleUnmanagedResource()
            {
                Console.WriteLine("Rozpoczynanie pracy...");
                Dispose(false);
                Console.WriteLine("Kończenie pracy...");
            }

            public void Dispose()
            {
                Dispose(true);
            }

            public void Dispose(bool disposing)
            {
                Console.WriteLine("Dispose: Rozpoczynanie pracy...");
                if (disposing)
                {
                    Console.WriteLine("Dispose: Usuwanie zasobów zarządzanych...");
                    System.GC.SuppressFinalize(this);
                }
                AppDomain.CurrentDomain.ProcessExit -= ProcessExitHandler;
                Console.WriteLine("Dispose: Usuwanie zasobów niezarządzalnych");
                Console.WriteLine("Dispose: Kończenie pracy");
            }
        }

        // leniwe inicjowanie wlasciwosci
        private class DataCache
        {
            // ??= sprawdza czy wartość internalFileStream jest różna od null
            public TemporaryFileStream FileStream => InternalFileStream ??= new TemporaryFileStream();

            private TemporaryFileStream? InternalFileStream { get; set; } = null;

            // System.Lazy<T>
            public TemporaryFileStream LazyStream => InternalLazyStream.Value;

            private Lazy<TemporaryFileStream> InternalLazyStream { get; }
                = new Lazy<TemporaryFileStream>(() => new TemporaryFileStream());
        }
    }
}