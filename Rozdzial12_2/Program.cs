using System;
using System.Collections.Generic;
namespace Rozdzial12_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var x = new Program();
            Console.CursorVisible = false;
            x.Sketch();
        }
        // TYPY GENERYCZNE
        public void Sketch()
        {
            Stack<Cell> path;
            path = new Stack<Cell>();
            Cell currentPosition;
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey();
                    switch(key.Key)
                {
                    case ConsoleKey.Z:
                        if(path.Count > 0)
                        {
                            currentPosition = path.Pop();
                            Console.SetCursorPosition(currentPosition.x, currentPosition.y);
                            Undo();
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        currentPosition = new Cell(Console.CursorLeft, Console.CursorTop - 1);
                        path.Push(currentPosition);
                        break;

                    case ConsoleKey.DownArrow:
                        currentPosition = new Cell(Console.CursorLeft, Console.CursorTop + 1);
                        path.Push(currentPosition);
                        break;

                    case ConsoleKey.LeftArrow:
                        currentPosition = new Cell(Console.CursorLeft - 1, Console.CursorTop);
                        path.Push(currentPosition);
                        break;

                    case ConsoleKey.RightArrow:
                        currentPosition = new Cell(Console.CursorLeft + 1, Console.CursorTop);
                        path.Push(currentPosition);
                        break;

                    default:
                        Console.Beep();
                        break;

                }
                Move(path);

            } while (key.Key != ConsoleKey.X);
        
        }

        private void Undo()
        {
            throw new NotImplementedException();
        }

        private void Move(Stack<Cell> stos)
        {
            if (stos.Count > 0)
            {
                Cell wartosc = stos.Peek();
                if (wartosc.x < 0 || wartosc.y < 0)
                { Console.Beep(); }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write(" ");
                    Console.CursorLeft = wartosc.x;
                    Console.CursorTop = wartosc.y;
                }
            }
        }
    }
    public struct Cell
    {
        public int x;
        public int y;
        public Cell(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
