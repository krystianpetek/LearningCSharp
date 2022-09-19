using System;

namespace Zdarzenia2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            DelegateOnBoardComputer dobc = new DelegateOnBoardComputer();
            dobc.CarsComputerEventLog += new DelegateOnBoardComputer.CarsComputerHandler(DisplayInformation);

            dobc.LogProcess();
            Console.ReadKey();
        }

        private static void DisplayInformation(string info)
        {
            Console.WriteLine(info);
        }
    }
}