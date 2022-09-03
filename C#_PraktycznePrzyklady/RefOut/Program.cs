using System;

namespace SZRefOut
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int outsideInt = 20;
            SomeMethod(out outsideInt);
            Console.WriteLine(outsideInt);

            SomeMethod1(ref outsideInt);
            Console.WriteLine(outsideInt);

        }
        private static void SomeMethod(out int insideInt)
        {
            insideInt = 0;
            insideInt = +10;
        }
        private static void SomeMethod1(ref int insideInt)
        {
            insideInt = insideInt + 10;
        }
    }
}
