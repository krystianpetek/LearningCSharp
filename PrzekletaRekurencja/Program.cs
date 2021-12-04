using System;

namespace PrzekletaRekurencja
{
    public class Program
    {
        static void Main(string[] args)
        {

            fun(5);
            


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


    }

}
