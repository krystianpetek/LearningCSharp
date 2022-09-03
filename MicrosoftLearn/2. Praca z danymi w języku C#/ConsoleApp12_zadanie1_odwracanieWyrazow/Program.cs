using System;

namespace ConsoleApp12_zadanie1_odwracanieWyrazow
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string pangram = "The quick brown fox jumps over the lazy dog";
            //TRUDNE
            string[] message = pangram.Split(' ');
            string[] newMessage = new string[message.Length];
            
            for (int i = 0;i<message.Length;i++)
            {
                char[] litery = message[i].ToCharArray();
                Array.Reverse(litery);
                newMessage[i] = new string(litery);
            }
            string result = String.Join(" ", newMessage);
            Console.WriteLine(result);
            
        }
    }
}
