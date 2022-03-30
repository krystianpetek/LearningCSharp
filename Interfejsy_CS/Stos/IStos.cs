using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfejsy_CS.Stos
{
    internal interface IStos<T>
    {
        void Push(T value);
        T Pop();
        T Peek { get; }
        int Count { get; }
        bool IsEmpty { get; }
        void Clear();
        T this[int index] { get; }
    }
}
