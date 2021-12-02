using System;

namespace SZTypyGeneryczne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // programujemy logike, ale nie przejmuijemy sie typem, robimy metody generyczne
            Compare<string> compareStrings = new Compare<string>();
            Compare<int> compareInts = new Compare<int>();
        }
        class Compare<AnyType>
        {
            public bool CompareTwoValues(AnyType a, AnyType b)
            {
                if(a.Equals(b))
                    return true;
                else
                    return false;
            }
        }
    }
}
