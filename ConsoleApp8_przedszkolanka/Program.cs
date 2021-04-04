using System;

namespace ConsoleApp8_przedszkolanka
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            
            for(int i = 0; i<N;i++)
            {
                string pobierzLinie = Console.ReadLine();
                string[] liczbyTab = pobierzLinie.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int a = int.Parse(liczbyTab[0]);
                int b = int.Parse(liczbyTab[1]);
                int mnoznikA = 1;
                int mnoznikB = 1;
                int wynikA = a;
                int wynikB = b;
                while(wynikA != wynikB)
                {
                    if(wynikA > wynikB)
                    {
                        wynikB = b * mnoznikB;
                        mnoznikB++;
                    }
                    else
                    {
                        wynikA = a * mnoznikA;
                        mnoznikA++;
                    }

                }
                Console.WriteLine(wynikA);
            }
        }
    }
}
