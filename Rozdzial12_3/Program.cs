using System.Collections.Generic;

namespace Rozdzial12_3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var x = new Stack<Cell>(10);
            var y = new Pair<Cell>(new Cell(1, 1));

            Pair<int, string> para = new Pair<int, string>(1914,"Shackleton wyrusza na Biegun Północny na statek Endurance");
            System.Console.WriteLine(para.first + ": " + para.second);            
        }
    }

    public class Cell
    {
        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }

    // Prosta klasa generyczna
    public class Stack<T>
    {
        public Stack(int maxSize)
        {
            InternalItems = new T[maxSize];
        }

        private T[] InternalItems { get; }

        public void Push(T data)
        { }

        public T Pop()
        { return InternalItems[InternalItems.Length - 1]; }
    }

    // generyczny interfejs
    internal interface IPair<T>
    {
        T First { get; set; }
        T Second { get; set; }
    }
    
    public struct Pair<T> : IPair<T>
    {
        public Pair(T f, T s)
        {
            First = f;
            Second = s;
        }
        public Pair(T f)
        {
            First = f;
            Second = default(T);
        }
        public T First { get; set; }
        public T Second { get; set; }
    }

    // wielokrotne implemenotwanie jednego interfejsu w tej samej klasie
    public interface IContainer<T>
    {
        ICollection<T> items { get; set; }
    }

    internal class Email
    {
    }

    internal class Phone
    {
    }

    public class Address
    {
    }

    public class Person : IContainer<Address>, IContainer<Phone>, IContainer<Email>
    {
        ICollection<Address> IContainer<Address>.items { get; set; }
        ICollection<Phone> IContainer<Phone>.items { get; set; }
        ICollection<Email> IContainer<Email>.items { get; set; }
    }
    interface IPair<TFirst, TSecond>
    {
        TFirst first { get; set; }
        TSecond second { get; set; }
    }
    public struct Pair<TFirst, TSecond> : IPair<TFirst, TSecond>
    {
        public TFirst first { get; set; }
        public TSecond second { get; set; }
        public Pair(TFirst x, TSecond y)
        {
            first = x;
            second = y;
        }
    }
}