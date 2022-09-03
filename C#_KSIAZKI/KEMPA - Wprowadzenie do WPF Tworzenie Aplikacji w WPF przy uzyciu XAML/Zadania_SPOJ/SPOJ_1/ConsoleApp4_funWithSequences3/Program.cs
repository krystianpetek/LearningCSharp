using System;
using System.Diagnostics;

namespace ConsoleApp4_funWithSequences3
{
    class Program
    {
        static void Main(string[] args)
        {
            // FUN WITH SEQUENCES (ACT3)
            
            /* DANE WEJSCIOWE
             * 5
             * -2 -2 -1 1 4
             * 6
             * -3 -2 -1 1 2 3
             */

            byte n = Convert.ToByte(Console.ReadLine());
            if (n < 2 || n > 100) return;

            string lineS = Console.ReadLine();
            string[] tabS = lineS.Split(" ",StringSplitOptions.RemoveEmptyEntries);
            int[] S = Array.ConvertAll(tabS, int.Parse);

            byte m = Convert.ToByte(Console.ReadLine());
            if (m < 2 || m > 100) return;

            string lineQ = Console.ReadLine();
            string[] tabQ = lineQ.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int[] Q = Array.ConvertAll(tabQ, int.Parse);
            
            for(int i = 0; i<Math.Min(n, m);i++)
            {
                if(S[i] == Q[i])
                {
                    Console.Write(i+1 + " ");
                }
            }
        

            // NIE MOJE
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Solution1();
            stopWatch.Stop();
            System.Console.WriteLine(stopWatch.Elapsed);
        }

        static void Solution1()
        {
            // read a sequence S
            int n = int.Parse(Console.ReadLine());
            string[] SS = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Debug.Assert(n == SS.Length);
            int[] S = Array.ConvertAll(SS, int.Parse);

            // read a sequence Q
            int m = int.Parse(Console.ReadLine());
            string[] QQ = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Debug.Assert(m == QQ.Length);
            int[] Q = Array.ConvertAll(QQ, int.Parse);

            for (int i = 0; i < Math.Min(n, m); i++)
                if (SS[i] == QQ[i])
                    Console.Write((i + 1) + " ");
            Console.WriteLine();
        }
    }
}
