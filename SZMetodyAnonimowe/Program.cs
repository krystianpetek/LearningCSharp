using System;
using System.Diagnostics;

namespace SZMetodyAnonimowe
{
    partial class Program
    {
        delegate int PointToAddMethod(int a, int b);
        static void dMain(string[] args)
        {
            //                                                              CZĘŚĆ 1
            Stopwatch stopwatch = new Stopwatch();
            for (int j = 0; j < 10; j++)
            {
                stopwatch.Restart();
                for (int i = 0; i < 100000; i++)
                {
                    PointToAddMethod pointAdd = delegate (int a, int b)
                    {
                        return a + b;
                    };
                    int c = pointAdd.Invoke(2, 3);
                }
                stopwatch.Stop();
                Console.WriteLine(stopwatch.ElapsedTicks.ToString());
//6321
//4858
//4542
//4579
//4510
//4536
//4673
//4625
//4591
//5029
            }
            Console.WriteLine();
            stopwatch = new Stopwatch();
            for (int j = 0; j < 10; j++)
            {
                stopwatch.Restart();
                for (int i = 0; i < 100000; i++)
                {
                    PointToAddMethod pointToAdd = Add;
                    pointToAdd.Invoke(2, 3);
                }
                stopwatch.Stop();
                Console.WriteLine(stopwatch.ElapsedTicks.ToString());
            }
            static int Add(int a,int b)
            {
                return a + b;
            }
            //22123
            //23146
            //20090
            //9155
            //12139
            //14741
            //12021
            //13481
            //12264
            //9979
        }

        //                                                      CZĘŚĆ 2
    }
    partial class Program
    {

        public delegate void SomeMethodDel();
        static void SomeMethod()
        {
            Console.WriteLine("Jestem tu !!");
        }
        static void dMain(string x)
        {
            SomeMethodDel someDel = SomeMethod;
            someDel.Invoke();
        }


    }
    public delegate void CallBack(int i);
    class SomeLongRunningData
    {
        public void SomeMethod(CallBack obj)
        {
            for (int i = 0; i < 1000; i++)
            {
                // robi się coś w tle
                obj(i);
            }
        }
    }

    partial class Program
    {
        static void CallBackMethod(int i)
        {
            Console.WriteLine(i);
        }
        static void Main()
        {
            SomeLongRunningData sm = new SomeLongRunningData();
            sm.SomeMethod(CallBackMethod);
        }
    }

}
