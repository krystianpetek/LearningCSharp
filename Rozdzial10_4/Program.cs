using System;
using System.IO;

namespace Rozdzial10_4
{
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
    }
    public class TemporaryFileStream : IDisposable
    {
        public TemporaryFileStream(string fileName)
        {
            File = new FileInfo(fileName);
            Stream = new FileStream(File.FullName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        }
        public FileInfo File { get; private set; }
        public FileStream Stream { get; private set; }
        public TemporaryFileStream() : this(Path.GetTempFileName()) { }
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
        #endregion
        public void Dispose( bool disposing)
        {
            if (disposing)
            {
                Stream?.Close();
            }
            try
            {
                File?.Delete();
            }
            catch(IOException ex)
            {
                Console.WriteLine(ex);
            }
            Stream = null;
            File = null;
        }
    }
    // 448
}
