// CHAPTER 17: Building Custom Collections

using Rozdzial17_1;
using System.Collections;
using System.Diagnostics.CodeAnalysis;

#region Using List<T>
static void UsingListT()
{
    List<string> list = new List<string>()
    {
        "Sneezy", "Happy", "Dopey", "Doc", "Sleepy", "Bashful", "Grumpy"
    };
    list.ToList();

    Console.WriteLine($"In alphabetical order {list[0]} is the first dwarf while {list[6]} is the last.");
    list.Remove("Grumpy");
}
UsingListT();
#endregion

#region Implementing IComparer<Contact>
List<Contact> contacts = new()
{
    new Contact("Krystian", "Petek"),
    new Contact("Patrycja", "Petek"),
    new Contact( firstName: "Józef", lastName: "Petek"),
    new Contact( firstName: "Teresa", lastName: "Petek")
};
contacts.Sort(new ByNameComparison());
contacts.ForEach((x) => Console.WriteLine(x.ToString()));
#endregion

#region Searching a List<T>
void SearchingAListT()
{
    List<string> listToSearch = new List<string>();
    int search;
    listToSearch.Add("public");
    listToSearch.Add("protected");
    listToSearch.Add("private");
    listToSearch.Sort();

    search = listToSearch.BinarySearch("protected internal");
    if (search < 0)
        listToSearch.Insert(~search, "protected internal");

    foreach (string accessModifier in listToSearch)
    {
        Console.WriteLine(accessModifier);
    }
}
SearchingAListT();
#endregion

#region Finding Multiple Items with FindAll()
void FindingMultipleItems()
{
    static bool Even(int value) => value % 2 == 0;

    List<int> list = new List<int>() { 1, 2, 3, 2 };
    List<int> result = list.FindAll(Even);
    foreach (var number in result)
    {
        Console.Write(number + " ");
    }
}
FindingMultipleItems();
#endregion

#region Dictionary Collections: Dictionary<TKey, TValue>
var colorMap = new Dictionary<string, ConsoleColor>()
{
    ["Error"] = ConsoleColor.Cyan,
    ["Warning"] = ConsoleColor.Yellow,
    ["Information"] = ConsoleColor.Green,
};
colorMap.Add("Verbose", ConsoleColor.White);
colorMap["Error"] = ConsoleColor.Red;
colorMap["Comment"] = ConsoleColor.Gray;
PrintKeyValuePair(colorMap);
static void PrintKeyValuePair(IEnumerable<KeyValuePair<string, ConsoleColor>> items)
{
    Console.WriteLine();
    foreach (var item in items)
    {
        Console.ForegroundColor = item.Value;
        Console.WriteLine(item.Key);
    }
}
#endregion

#region Equality two Contacts
var contact1 = new Contact("Krystian", "Petek");
var contact2 = new Contact("Krystian", "Petek");
ContactEquality contactEquality = new ContactEquality();

Console.WriteLine($"Equality two contact is: " + contactEquality.Equals(contact1, contact2));
#endregion

#region Sorted Collection: SortedDictionary<TKey, TValue> and SortedList<T>
SortedDictionary<string, int> sortedDictionary = new();
sortedDictionary.Add("Krystian", 1);

SortedList<string, int> sortedList = new SortedList<string, int>();
sortedList.Add("Krystian", 1);
#endregion

#region Stack<T> / Queue<T> / LinkedList<T>
Console.Write("Stack: ");
Stack<int> stack = new();
stack.Push(1);
stack.Push(2);
stack.Push(3);
foreach (var item in stack)
    Console.Write(item + " ");

Console.Write("\nQueue: ");
Queue<int> queue = new();
queue.Enqueue(1);
queue.Enqueue(2);
queue.Enqueue(3);
foreach (var item in queue)
    Console.Write(item + " ");

Console.Write("\nLinked list: ");
LinkedList<int> linkedList = new();
linkedList.AddLast(1);
linkedList.AddLast(2);
linkedList.AddLast(3);
foreach (var item in linkedList)
{
    Console.Write(item + " ");
}

#endregion

#region Providing an Indexer USE
Pair<int> pair = new Pair<int>(6, 10);
Console.Write("\nPair: ");
Console.Write(pair[PairItem.First]);
Console.Write(" ");
Console.Write(pair[PairItem.Second]);
#endregion

#region Index operator with variable parameters USE
var binaryTree = new BinaryTree<int>(5);
//var search = binaryTree[PairItem.First, PairItem.Second].Value;
#endregion

#region Yeilding Some C# Keywords
CSharpBuiltInTypes keywords = new();
Console.Write("\nKeywords using GetEnumerator: ");
foreach (var item in keywords)
{
    Console.Write(item + " ");
}
#endregion

#region Using Pait<T>.GetEnumerator() via foreach
var fullName = new Pair<string>("Inigo", "Montoya");
Console.Write("\nPair<T> foreach: ");
foreach (var name in fullName)
{
    Console.Write(name + " ");
}
#endregion

#region Iterate over BinaryTree via foreach
var jfkFamilyTree = new BinaryTree<string>("John Fitzgerald Kennedy")
{
    SubItems = new Pair<BinaryTree<string>>(
        // Father
        new BinaryTree<string>("Joseph Patrick Kennedy")
        {
            SubItems = new Pair<BinaryTree<string>>(
                // Grandparents (Father side)
                new BinaryTree<string>("Patrick Joseph Kennedy"),
                new BinaryTree<string>("Mary Augusta Hickey"))
        },
        // Mother
        new BinaryTree<string>("Rose Elizabeth Fitzgerald")
        {
            SubItems = new Pair<BinaryTree<string>>(
                // Grandparents (Mother size)
                new BinaryTree<string>("John Francis Fitzgerald"),
                new BinaryTree<string>("Mary Josephine Hannon"))
        })
};

Console.Write("\n\nFitzgerald Kennedy family: \n");
foreach (var name in jfkFamilyTree)
    Console.WriteLine(name);


#endregion

#region Iterate via Custom Enumerator for example by ReverseEnumerator
var reverse = new Pair<string>("Krystian", "Petek");

Console.Write("\nIterate in standard order: ");
foreach (string name in reverse.GetNotNullEnumerator())
    Console.Write(name + " ");

Console.Write("\nIterate in reverse order: ");
foreach (string name in reverse.GetReverseEnumerator())
    Console.Write(name + " ");
#endregion





#region Contact IMPLEMENTATION 
class Contact
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public Contact(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    public override string ToString()
    {
        return $"{LastName} {FirstName}";
    }
}
class ByNameComparison : IComparer<Contact>
{
    public int Compare(Contact? x, Contact? y)
    {
        if (Object.ReferenceEquals(x, y)) return 0;
        if (x == null) return 1;
        if (y == null) return -1;
        int result = StringCompare(x.LastName, y.LastName);
        if (result == 0) result = StringCompare(x.FirstName, y.FirstName);
        return result;
    }

    private int StringCompare(string lastNameX, string lastNameY)
    {
        if (Object.ReferenceEquals(lastNameX, lastNameY)) return 0;
        if (lastNameX == null) return 1;
        if (lastNameY == null) return -1;
        return lastNameX.CompareTo(lastNameY);
    }
}

class ContactEquality : IEqualityComparer<Contact>
{
    public bool Equals(Contact? x, Contact? y)
    {
        if (Object.ReferenceEquals(x, y))
            return true;
        if (x == null || y == null)
            return false;

        return x.LastName == y.LastName && x.FirstName == y.FirstName;
    }

    public int GetHashCode([DisallowNull] Contact obj)
    {
        int h1 = obj.FirstName == null ? 0 : obj.FirstName.GetHashCode();
        int h2 = obj.LastName == null ? 0 : obj.LastName.GetHashCode();
        return h1 * 23 + h2;
    }
}
#endregion

#region Pair<T> Providing an Indexer IMPLEMENTATION
struct Pair<T> : IPair<T>, IEnumerable<T>
{
    public IEnumerable<T> GetNotNullEnumerator()
    {
        if (First == null || Second == null)
            yield break;
        yield return First;
        yield return Second;
    }

    public IEnumerable<T> GetReverseEnumerator()
    {
        yield return Second;
        yield return First;
    }

    [System.Runtime.CompilerServices.IndexerName("Entry")] // i don't know why i use this instruction, in book author same doesn't know
    public T this[PairItem index] => index switch
    {
        PairItem.First => First,
        PairItem.Second => Second,
        _ => throw new NotImplementedException($"The enum {index} has not been implemented")
    };

    public T First { get; }

    public T Second { get; }

    public Pair(T first, T second) : this()
    {
        First = first;
        Second = second;
    }

    public IEnumerator<T> GetEnumerator()
    {
        yield return First;
        yield return Second;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

interface IPair<T>
{
    T First { get; }
    T Second { get; }
    T this[PairItem index] { get; }
}
enum PairItem
{
    First,
    Second
}
#endregion

#region BinaryTree<T> Index operator with variable parameters IMPLEMENTATION
class BinaryTree<T> : IEnumerable<T>
{
    public IEnumerator<T> GetEnumerator()
    {
        yield return Value;

        foreach (var tree in SubItems)
        {
            if (tree != null)
            {
                foreach (T item in tree)
                {
                    yield return item;
                }
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public BinaryTree(T value)
    {
        Value = value;
    }

    public T Value { get; }

    public Pair<BinaryTree<T>> SubItems { get; set; }

    public BinaryTree<T> this[params PairItem[]? branches]
    {
        get
        {
            BinaryTree<T> currentNode = this;
            int totalLevels = branches?.Length ?? 0;
            int currentLevel = 0;

            while (currentLevel < totalLevels)
            {
                System.Diagnostics.Debug.Assert(branches != null, $"{nameof(branches)} != null");
                currentNode = currentNode.SubItems[branches[currentLevel]];

                if (currentNode == null)
                    throw new IndexOutOfRangeException();

                currentLevel++;
            }
            return currentNode;
        }
    }


}
#endregion