using System;
using System.Collections.Generic;

namespace Rozdzial12_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
        public struct Nullable<T> : IFormattable, IComparable, IComparable<Nullable<T>>, System.Data.SqlTypes.INullable where T : struct
        {
            //public static implicit operator T?(T value) => new T?(value);
            //public static explicit operator T(T? value) => value!.Value;
            public bool IsNull => throw new NotImplementedException();
            public int CompareTo(object obj)
            {
                throw new NotImplementedException();
            }
            public int CompareTo(Nullable<T> other)
            {
                throw new NotImplementedException();
            }
            public string ToString(string format, IFormatProvider formatProvider)
            {
                throw new NotImplementedException();
            }
        }
        
    }

    // zestawy ograniczen, ograniczenia konstruktora
    public class EntityDictionary<TKey, TValue> : Dictionary<TKey, TValue> where TKey : IComparable<TKey>, IFormattable where TValue : EntityBase<TKey>, new()
    {
        public TValue MakeValue(TKey key)
        {
            TValue newEntity = new TValue();
            {
                newEntity.Key = key;
            }
            Add(newEntity.Key, newEntity);
            return newEntity;
        }
    }
    public class EntityBase <TKEY> where TKEY : notnull
    {
        public EntityBase(TKEY key)
        {
            Key = key;
        }
        public TKEY Key { get; set; }
    }

    //503
}
