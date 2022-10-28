using System.Security.Cryptography;
using System.Text;

namespace FileRenamer;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Type absolute path to directory:");
        var pathToDirectory = Console.ReadLine();

        Console.WriteLine("Type word to delete from files:");
        var wordToDelete = Console.ReadLine();

        var files = Directory.EnumerateFiles(pathToDirectory, wordToDelete+"*");

        foreach (var file in files)
        {
            Console.WriteLine(file);
        }
            Console.WriteLine("EXECUTE!? type: y/n");

            var check = Console.ReadLine();
            if (check != "Y".ToLower())
                return;
        
        foreach (var file in files)
        {
            var result = file.Replace(wordToDelete, "").Trim();
            try
            {
                File.Move(file, result);
            }
            catch (Exception ex)
            {
                var result2 = new StringBuilder();
                var chars = result.Split(".");
                for(int i = 0;i<chars.Length;i++)
                {
                    if (i == chars.Length-1)
                    {
                        result2.Append($"{i}.");
                    }
                    result2.Append(chars[i]);
                }

                File.Move(file, $"{result2}");
            }
        }

    }
}