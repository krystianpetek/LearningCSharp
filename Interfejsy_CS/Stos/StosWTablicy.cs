using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfejsy_CS.Stos
{
    public class StosWTablicy<T> : IStos<T>
    {
        private T[] tab;
        private int szczyt = -1;
        public StosWTablicy(int size = 10)
        {
            tab = new T[size];
            szczyt = -1;
        }
        public T Peek => throw new NotImplementedException();
        public T Pop() => throw new NotImplementedException();
        public void Push(T value) => throw new NotImplementedException();
        public int Count => szczyt + 1;
        public bool IsEmpty => szczyt == -1;
        public void Clear() => szczyt = -1;
        public T this[int index] => throw new NotImplementedException();
        public int Capacity => tab.Length;
        public void TrimExcess() => throw new NotImplementedException();
    }
}
