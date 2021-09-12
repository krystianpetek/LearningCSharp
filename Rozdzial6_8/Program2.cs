using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozdzial6_8
{
    partial class Program
    {
        // Definicja klasy zagnieżdżonej służącej do przetwarzania instrukcji z wiersza poleceń.
        private class CommandLine
        {
            public CommandLine(string[] arguments)
            {
                for (int argumentCounter = 0; argumentCounter < arguments.Length; argumentCounter++)
                {
                    switch (argumentCounter)
                    {
                        case 0:
                            Action = arguments[0].ToLower();
                            break;
                        case 1:
                            Action = arguments[1].ToLower();
                            break;
                        case 2:
                            Action = arguments[2].ToLower();
                            break;
                        case 3:
                            Action = arguments[3].ToLower();
                            break;
                    }
                }
            }
            public string? Action { get; }
            public string? Id { get; }
            public string? FirstName { get; }
            public string? LastName { get; }
        }
    }
}
