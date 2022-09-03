using System;
using System.Text;
namespace DzieleniePizzy
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = new StringBuilder();
            int T = int.Parse(Console.ReadLine());
            for(int i = 1; i <= T; i++)
            {
                long n = long.Parse(Console.ReadLine());    
                result.AppendLine(IleKawalkowFinal(n).ToString());
            }
            Console.WriteLine(result.ToString());
        }
        public static long IleKawalkowFinal(long n)
        {
            if (n == 1) return 2;
            return (n * n + n + 2) / 2;
        }
    }
    
}
