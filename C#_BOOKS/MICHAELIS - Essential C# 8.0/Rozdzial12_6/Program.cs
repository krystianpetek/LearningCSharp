namespace Rozdzial12_6
{
    internal class Program
    {
        // rozwiazanie z potencjalnei mozliwą kowariancją

        interface IReadOnlyPair<out T>
        {
            T First { get; }
            T Second { get; }
        }
        interface IPair<T>
        {
            T First { get; }
            T Second { get; }
        }

        public struct Pair<T> : IPair<T>, IReadOnlyPair<T>
        {
            public T First => throw new NotImplementedException();

            public T Second => throw new NotImplementedException();
        }

        // kontrwariancja

        public class Fruit { }
        public class Apple : Fruit { }
        public class Orange : Fruit { }

        interface ICompareThings<in T>
        {
            bool FirstIsBetter(T t1, T t2);
        }
        class FruitComparer : ICompareThings<Fruit>
        {
            public bool FirstIsBetter(Fruit t1, Fruit t2)
            {
                throw new NotImplementedException();
            }
        }


        static void Main()
        {
            ICompareThings<Fruit> fc = new FruitComparer();
            Apple apple1 = new Apple();
            Apple apple2 = new Apple();
            Orange orange = new Orange();

            // można porównywać jabłko z pomarańczą
            bool b1 = fc.FirstIsBetter(apple1, orange);
            // można porównywać jabłka
            bool b2 = fc.FirstIsBetter(apple1, apple2);

            ICompareThings<Apple> ac = fc;
            bool b3 = ac.FirstIsBetter(apple2, apple1);
        }


    }
}
