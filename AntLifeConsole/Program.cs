using AntLifeCL.Polimorfizm;
using System;

namespace AntLifeConsole
{
    internal class Program
    {
        //TestClass a = new TestClass();
        //static void Main(string[] args)
        //{
        //    Dictionary<int, TestClass> a = new Dictionary<int, TestClass>();
        //    a.Add(1,new TestClass { TestClassId = 1, TestClassName = "test 1" });
        //    a.Add(2,new TestClass { TestClassId = 2, TestClassName = "test 2" });
        //    a.Add(3,new TestClass { TestClassId = 3, TestClassName = "test 3" });
        //    a.Add(4,new TestClass { TestClassId = 4, TestClassName = "test 4" });

        //    foreach (var i in a)
        //    {
        //        Console.WriteLine(i.Key + " | " + i.Value.TestClassId + " " + i.Value.TestClassName);
        //    }
        //}

        static void Main(string[] args)
        {
            //BazaBody bb = new BazaBody();
            //bb.CreateBase("BazaBody", 1.1f, 2.2f); 
            //BazaMilitarna bm = new BazaMilitarna();
            //bm.CreateBase("BazaMilitarna", 9.9f, 10.1f);
            //bm.CreateBase("BazaMilitarna", 9.9f, 10.1f,50);

            //BazaBody bbm = new BazaMilitarna();
            //bbm.CreateBase("BazaMilitarna", 9.9f, 10.1f);

            BazaMilitarna x = new BazaMilitarna();
            x.CreateBase("BazaMilitarna", 9.9f, 10.1f, 30);
            BazaMilitarna y = new BazaMilitarna(60);
            y.CreateBase("bazamilitarna2", 6f, 5.4f);

            BazaBody mbb = new BazaMilitarna("Super baza", 33f, 44f, 325);
            BazaMilitarna mb = new BazaMilitarna("Super baza", 33f, 44f, 325);
            Console.WriteLine(mb.Name);
            Console.WriteLine(mb.Longitude);
            Console.WriteLine(mb.Latitude);
            Console.WriteLine(mb.WallResistance);
        }
    }
}
