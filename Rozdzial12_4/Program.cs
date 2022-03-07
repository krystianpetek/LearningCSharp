using System;
namespace Rozdzial12_4
{
    public class Program
    {
        public static void Main()
        {
            // krotki - typy o różnej arności
            Tuple<int, double, float, decimal> xTuple = new(1, 1.2d, 1.5f, 1.2m);
            ValueTuple<int> xTupleGeneric = new();
        }
        public class ValueTuple{ }
        public class ValueTuple<T1> : IComparable<ValueTuple<T1>>
        {
            public int CompareTo(ValueTuple<T1>? other)
            {
                throw new NotImplementedException();
            
            }
        }
        public class ValueTuple<T1, T2>{ };
        public class ValueTuple<T1, T2, T3>{ };
        public class ValueTuple<T1, T2, T3,T4>{ };
        public class ValueTuple<T1, T2, T3,T4,T5>{ };
        public class ValueTuple<T1, T2, T3,T4,T5,T6>{ };
        public class ValueTuple<T1, T2, T3,T4,T5,T6,T7>{ };
        // teoretycznie 8 argumentów MAX, ale ostania krotka to kolejny ValueTuple więc mozna robić w nieskończoność
        public class ValueTuple<T1, T2, T3, T4, T5, T6, T7,nextValueTuple> { };
        
    }
}