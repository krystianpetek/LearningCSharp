using System;
using System.IO;

namespace Rozdzial6_6
{
    public class Employee
    {
        // KONSTRUKTORY STATYCZNE
        // w pierwszej wykonywane są instrukcje z konstruktora statycznego a poźniej instancji
        static Employee()
        {
            Random randomgenerator = new Random();
            NextID = randomgenerator.Next(101, 999);
        }

        // Właściwości statyczne
        public static int NextID
        {
            get { return _NextID; }
            set
            {
                _NextID = value;
            }
        }
        private static int _NextID = 42;
    }
    // DEKLARACJA KLASY STATYCZNEJ
    public static class SimpleMath
    {
        public static int Max(params int[] numbers)
        {
            if(numbers.Length == 0)
            {
                throw new ArgumentException("tablica numbers nie moze być pusta", nameof(numbers));
            }
            int result;
            result = numbers[0];
            foreach(int number in numbers)
            {
                if (number > result)
                    result = number;
            }
            return result;
        }
        public static int Min(params int[] numbers)
        {
            if(numbers.Length == 0)
            {
                throw new ArgumentException("tablica numbers nie moze być pusta", nameof(numbers));
            }
            int result = numbers[0];
            foreach(int number in numbers)
            {
                if (number < result)
                    result = number;
            }
            return result;
        }
    }

    // METODY ROZSZERZAJĄCE (METODA STATYYCZNA)         ( raczej nie stosuj ich !!!)
    public static class DirectoryInfoExtension
    {
        public static void CopyTo(this DirectoryInfo sourceDirectory, string target, SearchOption option, string searchPattern)
        {
            // Metoda rozszerzająca instancje klasy DirectoryInfo
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[args.Length];
            for(int count = 0;count<args.Length;count++)
            {
                numbers[count] = args[count].Length;
            }
            Console.WriteLine($"Dlugość najdłuższego argumentu = {SimpleMath.Max(numbers)}");
            Console.WriteLine($"Dlugość najkrótszego argumentu = {SimpleMath.Min(numbers)}");
            
            // Metoda rozszerzająca instancje klasy DirectoryInfo
            DirectoryInfo directory = new DirectoryInfo(".\\Source");
            directory.CopyTo(".\\Target", SearchOption.AllDirectories, "*");
        }
    }
}
