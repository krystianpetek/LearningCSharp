using System.Collections.Generic;

namespace Rozdzial12_3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var x = new Stack<Cell>(10);
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
}