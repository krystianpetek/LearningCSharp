using System;

namespace Zadanie03_28
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1 sposob
            for(int i = 0;i<10;i++)
            {
                for(int j = 0;j<2;j++)
                    Console.Write(i);
            }
            // 2 sposob
            Console.WriteLine();
            for(int z = 0;z<20;z++)
                Console.Write(z/2);
        }
    }
}
