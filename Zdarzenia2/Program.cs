using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zdarzenia2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DelegateOnBoardComputer dobc = new DelegateOnBoardComputer();
            dobc.CarsComputerEventLog += new DelegateOnBoardComputer.CarsComputerHandler(DisplayInformation);

            dobc.LogProcess();
            Console.ReadKey();
        
            
        }

        static void DisplayInformation(string info)
        {
            Console.WriteLine(info);
        }
    }
}
