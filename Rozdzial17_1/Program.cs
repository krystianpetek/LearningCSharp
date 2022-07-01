// CHAPTER 17: Building Custom Collections

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

#region Providing an Indexer
//750
#endregion

#region Contact
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