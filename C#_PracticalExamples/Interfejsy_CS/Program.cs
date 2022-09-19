using Interfejsy_CS.ExplicitImplicit;
using Interfejsy_CS.Stos;
using Interfejsy_CS.Device;
using Interfejsy_CS.LeftRight;

IStos<int> s1 = new StosWTablicy<int>();
Console.WriteLine(s1 is IStos<int>);
Console.WriteLine(s1 is StosWTablicy<int>);

IStos<int> s = new StosWTablicy<int>(10);
Console.WriteLine(s.IsEmpty);
Console.WriteLine(((StosWTablicy<int>)s).Capacity);

// IEquatable - taki sam, czy dwie instancje sa sobie równe, equal
// IComparable - oznacza wdrożenie w projektowanym typie "porządku wewnętrznego", kazde dwie instancje są porównywanlne(np, mozna stwierdzic ktora jest mniejsza/większa), wiedza ta jest potrzebna do sortowania czy wyszukiwania
// IComparer - dostarcza metodę do porównywania dwóch obiektów. oznacza dostarczenie "zewnetrznego" sposoby porównywania elementó dla algorytmów sortowania i szybkiego wyszukiwania
// IDisposable - wlasne mechanizmy zwalniania zasobów zewnętrzntych, np. dostep do plikow i strumieni danych czy bazy danych, wspolpracuje z instrukcją using(), nie deklaracją using
// ICloneable - dostarczają własną, niestandardową metodę tworzenia kopii elementu(zamiast predefiniować Object.MemberwiseClone)
// IEnumerable - kolekcje implementujące ten interfejs definiują iterator, pozwalają na przeglądanie swojej zawartości za pomocą pętli foreach. Typ IEnumerable wykorzystywany jest w technologii LINQ.

// ICollection
// IList
// ISet
// IDictionary
// ISerializable i wiele innych

ICollection<int> kolekcja = new HashSet<int> { 2, 1, 5, 3, 4 };
kolekcja.Add(0);
Console.WriteLine(string.Join(' ', kolekcja));

kolekcja = new SortedSet<int> { 2, 1, 5, 3, 4 };
kolekcja.Add(0);
Console.WriteLine(string.Join(" ", kolekcja));

A a = new A(); // klasa
IA ia = new A(); // interface

a.M(); // niejawna 

((IA)a).M(); // jawna klasa
ia.M(); // jawna interface

Copier copier = new Copier();
copier.Run();