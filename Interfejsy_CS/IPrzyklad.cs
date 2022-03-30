using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfejsy_CS
{
    internal interface IPrzyklad
    {
        
    }
    class MojPrzyklad : IPrzyklad
    {

    }

    public interface IStos<T>
    {
        public void Push(T value);
        public T Pop();
        public T Peek { get; }
        public int Count { get; }
        public bool IsEmpty { get; }
        public void Clear();
        public T this[int index] { get; }
    }
    public class StosWtablicy<T> : IStos<T>
    {
        private T[] tab;
        private int szczyt = -1;
        public StosWtablicy(int size = 10)
        {
            tab = new T[size];
            szczyt = -1;
        }
        public T Peek => throw new NotImplementedException();
        public T Pop()
        {
            throw new NotImplementedException();
        }
        public void Push(T value)
        {
            throw new NotImplementedException();
        }
        public int Count => szczyt + 1;
        public bool IsEmpty => szczyt == -1;
        public void Clear() => szczyt = -1;
        public T this[int index] => throw new NotImplementedException();
        public int Capacity => tab.Length;
        public void TrimExcess() => throw new NotImplementedException();
    }
    public class StosLinkedNodes<T> : IStos<T>
    {
        private class Node
        {
            T data;
            Node next;
        }
        private Node head;
        private Node top;
        private int counter;

        public StosLinkedNodes()
        {
            head = top = null;
            counter = 0;
        }
        public int Count => counter;
        public void Clear()
        {
            top = head = null;
            counter = 0;
        }
        public bool IsEmpty => counter == 0;
        public T Peek => throw new NotImplementedException();

        public T Pop()
        {
            throw new NotImplementedException();
        }
        public void Push(T value)
        {
            throw new NotImplementedException();
        }
        public T this[int index] => throw new NotImplementedException();
    }

    public abstract class AbstractStos<T>
    {
        private int counter;
        public AbstractStos()
        {
            counter = 0;
        }
        public abstract void Push(T value);
        public abstract T Pop();
        public abstract T Peek();
        public int Count => counter;
        public abstract void Clear();
        public abstract T this[int index] { get; }
    }
}
