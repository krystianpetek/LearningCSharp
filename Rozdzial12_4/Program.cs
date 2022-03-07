using System;
namespace Rozdzial12_4
{
    public class Program
    {
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
        public static void Main()
        {
            // krotki - typy o różnej arności
            Tuple<int, double, float, decimal> xTuple = new(1, 1.2d, 1.5f, 1.2m);
            ValueTuple<int> xTupleGeneric = new();
            (string, Contact) keyValuePara;
            keyValuePara = ("555-55-5555", new Contact("Indigo","Montoya"));
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
        
    }
}