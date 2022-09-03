using System;
namespace PrzekletaRekurencja
{
    public class Program
    {
        static void Main3(string[] args)
        {
            fun(3);
            void fun(int n)
            {
                if (n > 0)
                {
                    fun(n - 1);
                    Console.WriteLine(n);
                    fun(n - 1);
                }
            }
        }
        static void Main()
        {
            fun(3);
            void fun(int n)
            {
                int i = 0, j = i + 1;

                for(i = 1;i<=n;i++)
                {
                    Console.WriteLine(i);
                    for (;j<i;j++)
                    {
                        Console.WriteLine(j);
                    }
                }
            }
        }
    }
}
