using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfejsy_CS.Stos
{
    public abstract class AbstractStos<T>
    {
        private int counter;
        public AbstractStos()
        {
            counter = 0;
        }
        public abstract void Push(T value);
        public abstract T Pop();
        public abstract T Peek { get; }
        public int Count => counter;
        public bool IsEmpty => Count == 0;
        public abstract void Clear();
        public abstract T this[int index] { get; }
    }
}
