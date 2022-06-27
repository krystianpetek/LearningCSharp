using System;
using System.Collections.Generic;

namespace Rozdzial12_5
{

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

    // Używanie interfejsu fabrycznego zamiast ograniczenia dotyczącego konstruktora
    public class EntityBase<TKEY> where TKEY : notnull
    {
        public EntityBase(TKEY key)
        {
            Key = key;
        }
        public TKEY Key { get; set; }
    }

    public interface IEntityFactory<TKey, TValue>
    {
        TValue CreateNew(TKey key);
    }

    public class EntityDictionary<TKey, TValue, TFactory> : Dictionary<TKey, TValue>
        where TKey : IComparable, IFormattable
        where TValue : EntityBase<TKey>
        where TFactory : IEntityFactory<TKey, TValue>, new()
    {
        public TValue New(TKey key)
        {
            TFactory factory = new TFactory();
            TValue newEntity = factory.CreateNew(key);
            Add(newEntity.Key, newEntity);
            return newEntity;
        }
    }


    // Deklarowanie typu encji używanych w typie EntityDictionary<…>
    public class Order : EntityBase<Guid>
    {
        public Order(Guid key) : base(key)
        {

        }
    }

    public class OrderFactory : IEntityFactory<Guid, Order>
    {
        public Order CreateNew(Guid key)
        {
            return new Order(key);
        }
    }

    public static class MathEx
    {
        public static T Max<T>(T first, params T[] values) where T : IComparable<T>
        {
            T maximum = first;
            foreach (T item in values)
            {
                if (item.CompareTo(maximum) > 0)
                    maximum = item;
            }
            return maximum;
        }

        public static T Min<T>(T first, params T[] values) where T : IComparable<T>
        {
            T minimum = first;
            foreach (T item in values)
            {
                if (item.CompareTo(minimum) < 0)
                    minimum = item;
            }
            return minimum;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine(MathEx.Max<int>(7, 490));
            Console.WriteLine(MathEx.Min<string>("R.O.U.S.", "Fireswamp"));

            // inferencja argumentu określającego typ, na podstawie przekazanych argumentów
            Console.WriteLine(MathEx.Max(7, 490));
            Console.WriteLine(MathEx.Max("R.O.U.S.", "Fireswamp"));


            IEnumerable<string> strings = new List<string>();
            IEnumerable<object> objects = strings;

        }
    }

}
