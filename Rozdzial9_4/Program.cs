using System;
using System.Diagnostics;
using System.IO;

namespace Rozdzial9_4
{
    // WYLICZENIA
    internal class Program
    {
        private enum ConnectionState
        {
            Disconnected, Connecting, Connected, Disconnecting
        }

        private enum ConnectionStateJawne : short
        {
            Disconnected, // 0
            Connecting = 10, // 10
            Connected, // 11
            Joined = Connected, // 11
            Disconnecting // 12
        }

        private enum StatusPolaczenia
        {
            Rozlaczono, Laczenie, Polaczono, Rozlaczanie
        };

        private enum StatusPolaczenia2
        {
            Rozlaczono, Laczenie, Polaczono, Rozlaczanie
        }

        [Flags]
        public enum FileAttributesMOD
        {
            ReadOnly = 1 << 0,              // 000000000000000001
            Hidden = 1 << 1,                // 000000000000000010
            System = 1 << 2,                // 000000000000000100
            Directory = 1 << 4,             // 000000000000010000
            Archive = 1 << 5,               // 000000000000100000
            Device = 1 << 6,                // 000000000001000000
            Normal = 1 << 7,                // 000000000010000000
            Temporary = 1 << 8,             // 000000000100000000
            SparseFile = 1 << 9,            // 000000001000000000
            ReparsePoint = 1 << 10,         // 000000010000000000
            Compressed = 1 << 11,           // 000000100000000000
            Offline = 1 << 12,              // 000001000000000000
            NotContentIndexed = 1 << 13,    // 000010000000000000
            Encrypted = 1 << 14,            // 000100000000000000
            IntegrityStream = 1 << 15,      // 001000000000000000
            NoScrubData = 1 << 17,          // 100000000000000000
        }

        // Definiowanie w wyliczeniu wartości reprezentujących często używane kombinacje flag
        [Flags]
        private enum DistributedChannel
        {
            None = 0,
            Transacted = 1,
            Queued = 2,
            Encrypted = 4,
            Persisted = 16,
            FaultTolerant = Transacted | Queued | Persisted
        }

        private static void Main(string[] args)
        {
            int? connectionState = null;
            switch (connectionState)
            {
                case 0: break;
                case 1: break;
                case 2: break;
                case 3: break;
            }

            ConnectionState connectionState2 = ConnectionState.Disconnected;
            switch (connectionState2)
            {
                case ConnectionState.Disconnected: break;
                case ConnectionState.Connected: break;
                case ConnectionState.Disconnecting: break;
                case ConnectionState.Connecting: break;
            }
            // RZUTOWANIE MIEDZY TABLICAMI OPARTYMI NA WYLICZENIACH
            StatusPolaczenia[] status = (StatusPolaczenia[])(Array)new StatusPolaczenia2[42];


            // Konwersja miedzy wyliczeniami a lancuchami znaków
            System.Diagnostics.Trace.WriteLine($"Aktualny status połączenia to {StatusPolaczenia.Laczenie}");
            Console.WriteLine($"Aktualny status połączenia to {StatusPolaczenia.Laczenie}");

            //Konwersja łańcucha znaków na wartość typu wyliczeniowego za pomocą metody Enum.Parse()
            ThreadPriorityLevel priority = (ThreadPriorityLevel)Enum.Parse(typeof(ThreadPriorityLevel), "Idle");
            Console.WriteLine(priority);

            // Przekształcanie łańcucha znaków na wyliczenie za pomocą metody Enum.TryParse<T>()
            System.Diagnostics.ThreadPriorityLevel priority2;
            if (Enum.TryParse("Idle", out priority2))
            {
                Console.WriteLine(priority2);
            }

            // WYLICZENIA JAKO FLAGI
            string fileName = @"enumtest.txt";
            if(!File.Exists(fileName))
                File.Create(fileName);
            System.IO.FileInfo file = new System.IO.FileInfo(fileName);
            file.Attributes = FileAttributes.Hidden | FileAttributes.ReadOnly;
            Console.WriteLine($"{file.Attributes} = {(int)file.Attributes}");
            if (!(System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Linux) ||
                System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.OSX)))
            {
                if (!file.Attributes.HasFlag(FileAttributes.Hidden))
                {
                    throw new Exception("Plik nie jest ukryty.");
                }
                if ((file.Attributes & FileAttributes.ReadOnly) != FileAttributes.ReadOnly)
                {
                    throw new Exception("Plik nie jest przeznaczony tylko do odczytu.");
                }
            }
            Console.WriteLine(Enum.IsDefined(typeof(FileAttributesMOD), "Hidden"));

        }
    }
}