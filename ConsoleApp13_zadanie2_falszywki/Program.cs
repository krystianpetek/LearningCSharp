using System;

namespace ConsoleApp13_zadanie2_falszywki
{
    class Program
    {
        static void Main(string[] args)
        {
            string orderStream = "B123,C234,A345,C15,B177,G3003,C235,B179";
            string[] newOrder = orderStream.Split(",");
            for( int i=0; i<newOrder.Length;i++)
            {
                if(newOrder[i].StartsWith('B'))
                    Console.WriteLine(newOrder[i]);
            }
            Console.WriteLine();
            //EXAMPLE 2
            foreach(var item in newOrder)
            {
                if(item.StartsWith('B'))
                    Console.WriteLine(item);
            }
        }
    }
}
