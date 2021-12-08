using System;
using System.Collections.Generic;
using DokumentacjaCS.Interface;
namespace DokumentacjaCS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var p2D1 = new Point(0, 0);
            Console.WriteLine(p2D1);
            var p2D2 = new Point(10, 20);
            Console.WriteLine(p2D2);

            var pair1 = new Pair<int, string>(1, "two");
            Console.WriteLine(pair1);
            var pair2 = new Pair<Point, string>(new Point(100, 3), "trzysta");
            Console.WriteLine(pair2);

            Console.WriteLine();
            Point p3D1 = new Point3D(5, 3, 7);
            Console.WriteLine(p3D1);

            EditBox editbox = new EditBox();
            IControl control = editbox;
            IDataBound dataBound = editbox;

            var turnip = SomeRootVegetable.Turnip;

            var spring = Seasons.Spring;
            var staringOnEquinox = Seasons.Spring | Seasons.Autumn;
            var theYear = Seasons.All;

            int? optionalInt = default;
            optionalInt = 5;
            string? optionalText = default;
            optionalText = "Hello World!";

            // krotka
            (double Sum, int Count) t2 = (4.5, 3);
            Console.WriteLine($"Sum of {t2.Count} elements is {t2.Sum}");
            Console.WriteLine();

            Color color = Color.White;
            Console.WriteLine(color); 
            Console.WriteLine();

            Color.SwapColorExample();
            Console.WriteLine();

            int x = 3, y = 4, z = 5;
            string s = "x={0} y={1} z={2}";
            object[] argu = new object[3];
            argu[0] = x;
            argu[1] = y;
            argu[2] = z;
            Console.WriteLine(s, argu);
            Console.WriteLine();

            Entity.SetNextSerialNo(1000);
            Entity e1 = new();
            Entity e2 = new();
            Console.WriteLine(e1.GetSerialNo());
            Console.WriteLine(e2.GetSerialNo());
            Console.WriteLine(Entity.GetNextSerialNo());
            Console.WriteLine();

            Dictionary<string, object> dic = new();
            Expression e = new Operation(new VariableReference("x"), '+', new Constant(3)); // x + 3
            e = new Operation(new VariableReference("x"), '*', new Operation(new VariableReference("y"),'+',new Constant(2))); // x * (y + 2)
            dic["x"] = 3;
            dic["y"] = 5;
            Console.WriteLine(e.Evaluate(dic));

            Console.WriteLine();
            PrzeciazanieMetod.PrzykladyUzyciaPrzeciazenMetod();

            Console.WriteLine();
            MyList<string> list1 = new();
            MyList<string> list2 = new(10);
            list2.Capacity = 100;
            int i = list2.Count;
            int j = list2.Capacity;
            Console.WriteLine(i + " "+ j);

            MyList<string> names = new();
            names.Add("Liz");
            names.Add("Martha");
            names.Add("Beth");
            for (int ai = 0; ai < names.Count; ai++)
            {
                string sa = names[ai];
                names[ai] = sa.ToUpper();
                Console.WriteLine(names[ai]);
            }
            Console.WriteLine();

            EventExample.Usage();
        }
    }

    public enum SomeRootVegetable
    {
        HorseRadish, Radish,Turnip
    }
    public enum Seasons
    {
        None = 0,
        Summer = 1,
        Autumn = 2,
        Winter = 3,
        Spring = 8,
        All = Summer | Autumn | Winter | Spring
    }
}
