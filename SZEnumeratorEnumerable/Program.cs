using System;
using System.Collections.Generic;

namespace SZEnumeratorEnumerable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region LISTA
            List<int> myList = new List<int>();
            myList.Add(100);
            myList.Add(200);
            myList.Add(300);
            myList.Add(400);
            myList.Add(1000);
            myList.Add(1001);
            myList.Add(1002);
            #endregion
            IEnumerable<int> ienumerable = myList; // nie ma pojecia w jakim jest stanie
            foreach(var item in ienumerable)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            IEnumerator<int> ienumerator = myList.GetEnumerator(); // wie w jakim momencie iteracji jest
            while(ienumerator.MoveNext())
            {
                Console.WriteLine(ienumerator.Current);
            }

            Console.WriteLine();
            ienumerator.Reset();
            PetlaDo1000(ienumerator);
        }
        
        // WYJAŚNIENEI
        static void PetlaDo1000(IEnumerator<int> e)
        {
            while (e.MoveNext())
            {
                Console.WriteLine(e.Current.ToString());
                if (e.Current > 999)
                {
                    PetlaPowyzej1000(e);
                }
            }
        }
        static void PetlaPowyzej1000(IEnumerator<int> e)
        {
            while (e.MoveNext())
            {
                Console.WriteLine(e.Current.ToString());
            }
        }
    }
}
