namespace Rozdzial12_4
{
    public class Program
    {
        public class ValueTuple
        { }

        public class ValueTuple<T1> : IComparable<ValueTuple<T1>>
        {
            public int CompareTo(ValueTuple<T1>? other)
            {
                throw new NotImplementedException();
            }
        }

        public class ValueTuple<T1, T2>
        {
            private string v;
            private Contact contact;

            public ValueTuple(string v, Contact contact)
            {
                this.v = v;
                this.contact = contact;
            }
        }

        public class ValueTuple<T1, T2, T3>
        { };

        public class ValueTuple<T1, T2, T3, T4>
        { };

        public class ValueTuple<T1, T2, T3, T4, T5>
        { };

        public class ValueTuple<T1, T2, T3, T4, T5, T6>
        { };

        public class ValueTuple<T1, T2, T3, T4, T5, T6, T7>
        { };

        // teoretycznie 8 argumentów MAX, ale ostania krotka to kolejny ValueTuple więc mozna robić w nieskończoność
        public class ValueTuple<T1, T2, T3, T4, T5, T6, T7, nextValueTuple>
        { };

        public static void Main()
        {
            // krotki - typy o różnej arności
            Tuple<int, double, float, decimal> xTuple = new(1, 1.2d, 1.5f, 1.2m);
            ValueTuple<int> xTupleGeneric = new();
            (string, Contact) keyValuePara;
            keyValuePara = ("555-55-5555", new Contact("Indigo", "Montoya"));
            // przed C# 7.0
            ValueTuple<string, Contact> keyValueParaPrzed7;
            keyValueParaPrzed7 = new ValueTuple<string, Contact>("555-55-5555", new Contact("Inigo", "Montoya"));
        }

        public class Contact
        {
            public string Imie { get; set; }
            public string Nazwisko { get; set; }

            public Contact(string imie, string nazwisko)
            {
                Imie = imie;
                Nazwisko = nazwisko;
            }
        }

        // zagnieżdzone typy generyczne
        public class Container<T1, T2>
        {
            public class Nested<T2>
            {
                public void Method(T1 param0, T2 param2)
                {
                }
            }
        }

        // deklaracja binarytree bez ograniczen
        public class Pair<T>
        {
            public Pair(T first, T second)
            {
                First = first;
                Second = second;
            }

            public T First { get; set; }
            public T Second { get; set; }
        }

        public class BinaryTree<T> where T : System.IComparable<T>
        {
            public BinaryTree(T item)
            {
                _item = item;
            }

            public T _item { get; set; }

            public Pair<BinaryTree<T>> SubItems
            {
                get { return _SubItems; }
                set
                {
                    switch (value)
                    {
                        // Obsługa wartości null została pominięta, aby zwiększyć czytelność.
                        // Używanie dopasowania do wzorca z wersji C# 8.0. W starszych
                        // wersjach zastosuj sprawdzanie wartości null.
                        case
                        {
                            First: { _item: T first },
                            Second: { _item: T second }
                        }:
                            if (first.CompareTo(second) < 0)
                            {
                                // Element first jest mniejszy niż second.
                            }
                            else
                            {
                                // Element second jest mniejszy lub równy względem first.
                            }
                            break;

                        default:
                            throw new InvalidCastException(@$"Nie da się posortować elementów. Typ {typeof(T) } nie obsługuje interfejsu IComparable<T>");
                    }
                    _SubItems = value;
                }
            }

            private Pair<BinaryTree<T>?>? _SubItems;
        }

        // ograniczenia parametru
        public class EntityDictionary<Tkey, Tvalue> : Dictionary<Tkey, Tvalue> where Tkey : notnull where Tvalue : EntityBase
        {
        }

        public class EntityBase
        {
        }
    }
}