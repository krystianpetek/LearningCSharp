using Microsoft.Extensions.Logging;
using System;
using System.IO;
using X.Y.Z;

namespace Rozdzial10_3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            ILogger logger = loggerFactory.CreateLogger(categoryName: "Console");
            logger.LogInformation($@"Kody triażu: = '{string.Join("', '", args)}'");
            logger.LogWarning("To test kodów triażu...");

            // namespace zagniezdzone
            X.Y.Z.XYZ program = new X.Y.Z.XYZ();
            // using X.Y.Z;
            XYZ program2 = new XYZ();
            program2.Dodawanie(5, 1);
        }
    }

    public static class ByteArrayDataSource
    {
        private static byte[] LoadData()
        {
            byte[] data = new byte[1000];

            return data;
        }

        private static WeakReference<byte[]>? Data { get; set; }

        public static byte[] GetData()
        {
            byte[]? target;
            if (Data is null)
            {
                target = LoadData();
                Data = new WeakReference<byte[]>(target);
                return target;
            }
            else if (Data.TryGetTarget(out target))
            {
                return target;
            }
            else
            {
                // przypisanie do zmiennej co powoduje utworzenie silnej referencji
                target = LoadData();
                Data.SetTarget(target);
                return target;
            }
        }
    }

    public class TemporaryFileStream
    {
        public FileInfo? File { get; private set; }
        public FileStream? Stream { get; private set; }

        public TemporaryFileStream(string fileName)
        {
            File = new FileInfo(fileName);
            // lepsze rozwiazanie to wywolanie FileOptions.DeleteOnClose
            Stream = new FileStream(File.FullName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        }

        public TemporaryFileStream() : this(Path.GetTempFileName())
        {
        }

        ~TemporaryFileStream()
        {
            try
            {
                Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Zapis zdarzeń itp, lub może wyrzucenie błędu");
            }
        }

        public void Close()
        {
            Stream?.Dispose();
            try
            {
                File?.Delete();
            }
            catch (IOException exception)
            {
                Console.WriteLine(exception);
            }
            Stream = null;
            File = null;
        }
    }
}

namespace X
{
    namespace Y
    {
        namespace Z
        {
            public class XYZ
            {
                /// <summary>
                /// Dodawanie 2 liczb
                /// </summary>
                /// <param name="x"></param>
                /// <param name="y"></param>
                public void Dodawanie(int x, int y)
                {
                    Console.WriteLine(x + y);
                }
            }
        }
    }
}