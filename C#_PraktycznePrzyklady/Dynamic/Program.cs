using System;

namespace SZDynamic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string toJestString = "aa";
            toJestString.ToUpper(); // AA

            dynamic tojestDynamic = "aa";
            tojestDynamic.ToUpper();


            int myInt = 1 + 3;
            var mvar = 1 + 3;
            dynamic dyn = 1 + 3;
            object obj = 1 + 3;

            Console.WriteLine(myInt.GetType());
            Console.WriteLine(mvar.GetType());
            Console.WriteLine(dyn.GetType());
            Console.WriteLine(obj.GetType());

            dynamic dyna;
            int a = 20;
            dyna = a;
            string b = "To jest dynamic !";
            dyna = b;
            DateTime dt = DateTime.Now;
            dyna = dt;

            cls.ExampleMethod("CLS");

            dls = new ExampleClass();
            //dls.ExampleClass("DLS");
        }

        static ExampleClass cls = new ExampleClass();
        static dynamic dls;

    }
    public class ExampleClass
    {
        public void ExampleMethod(string text)
        {
            var a = text;
        }
    }
}
