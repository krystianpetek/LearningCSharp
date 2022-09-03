using System;

namespace ConsoleApp11_splitJoin
{
    class Program
    {
        static void Main(string[] args)
        {
            string value = "abc123";
            char[] valueArray = value.ToCharArray();
            Array.Reverse(valueArray);
            string result = new string(valueArray);
            Console.WriteLine(result);

            string value2 = "abc123";
            char[] valueArray2 = value2.ToCharArray();
            Array.Reverse(valueArray2);
            string result2 = String.Join(",", valueArray2);
            Console.WriteLine(result2);

            string[] items = result2.Split(",");
            foreach(string item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
