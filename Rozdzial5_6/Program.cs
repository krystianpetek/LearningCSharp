using System;
using System.IO;

namespace Rozdzial5_6
{
    // REKURENCJA - liczenie linii kodu w każdym pliku w danej scieżce ( nie liczy pustych linii )

    // C:\GITHUB\CS8.0_Ksiazka\
    // C:\GITHUB\CS8.0_Ksiazka\Rozdzial5_6\
    public static class LineCounter
    {

        public static void Main(string[] args)
        {
            int totalLineCount = 0;
            //string directory;
            //if (args.Length > 0)
            //    directory = args[0];
            //else
            //    directory = Directory.GetCurrentDirectory();
            //totalLineCount = DirectoryCountLines(directory);
            if (args.Length > 1)
                totalLineCount = DirectoryCountLines(args[0], args[1]);
            else if (args.Length > 0)
                totalLineCount = DirectoryCountLines(args[0]);
            else
                totalLineCount = DirectoryCountLines();

            Console.WriteLine(totalLineCount);
        }

        static int DirectoryCountLines()
        {
            return DirectoryCountLines(Directory.GetCurrentDirectory());
        }
        
        //static int DirectoryCountLines(string directory)
        //{
        //    int lineCount = 0;
        //    foreach (string file in Directory.GetFiles(directory, "*.cs"))
        //    {
        //        lineCount += CountLines(file);
        //    }
        //    foreach (string subdirectory in Directory.GetDirectories(directory))
        //    {
        //        //Console.WriteLine(Directory.GetDirectories(directory)[0]);
        //        lineCount += DirectoryCountLines(subdirectory);
        //    }
        //    return lineCount;
        //}

        //static int DirectoryCountLines(string directory)
        //{
        //    return DirectoryCountLines(directory, "*.cs");
        //}

        static int DirectoryCountLines(string directory, string extension = "*.c*") // .cs .csproj
        {
            int lineCount = 0;
            foreach(string file in Directory.GetFiles(directory, extension))
            {
                lineCount += CountLines(file);
            }
            foreach(string subdir in Directory.GetDirectories(directory))
            {
                lineCount += DirectoryCountLines(subdir,extension);
            }
            return lineCount;
        }

        private static int CountLines(string file)
        {
            string? line;
            int lineCount = 0;
            FileStream stream = new FileStream(file, FileMode.Open);
            StreamReader reader = new StreamReader(stream);
            line = reader.ReadLine();
            while (line is object)
            {
                if (line.Trim() != "")
                {
                    lineCount++;
                }
                line = reader.ReadLine();
            }
            reader.Close();
            return lineCount;
        }

    }
}