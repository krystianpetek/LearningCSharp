﻿using System;

namespace ConsoleApp4_usuwanieBlokow
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag = true;
            if (flag) Console.WriteLine(flag);

            string name = "steve";
            if (name == "bob")
                Console.WriteLine("Found Bob");
            else if (name == "steve")
                Console.WriteLine("Found Steve");
            else
                Console.WriteLine("Found Chuck");

            int[] numbers = { 4, 8, 15, 16, 23, 42 };
            int total = 0;
            bool found = false;

            foreach (int number in numbers)
            {
                total += number;
                if (number == 42) found = true;
            }
            
            if(found) Console.WriteLine("Set contains 42");
            
            Console.WriteLine($"Total: {total}");
        }
    }
}
