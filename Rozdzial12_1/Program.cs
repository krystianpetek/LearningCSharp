using System;
using System.Collections.Generic;

namespace Rozdzial12_1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var x = new Program();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.CursorVisible = false;
            x.Sketch();
        }

        public void Sketch()
        {
            Stack<Cell> path = new Stack<Cell>();
            Cell currentPosition;
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.Z:
                        if (path.Count >= 1)
                        {
                            currentPosition = path.Pop();
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

        public void Move(Stack<Cell> stos)
        {
            if (stos.Count > 0)
            {
                Cell wartosc = stos.Peek();
                if (wartosc.X < 0 || wartosc.Y < 0)
                { Console.Beep(); }
                else
                {
                    Console.Write(" ");
                    Console.CursorLeft = wartosc.X;
                    Console.CursorTop = wartosc.Y;
                }
            }
        }

        public struct Cell
        {
            public int X;
            public int Y;

            public Cell(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
    }
}