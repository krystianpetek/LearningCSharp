/// CHAPTER 17: Building Custom Collections

// Using List<T>
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

// Implementing IComparer<Contact>
List<Contact> contacts = new()
{
    new Contact("Krystian", "Petek"),
    new Contact("Patrycja", "Petek"),
    new Contact( firstName: "Józef", lastName: "Petek"),
    new Contact( firstName: "Teresa", lastName: "Petek")
};
contacts.Sort(new ByNameComparison());
contacts.ForEach((x) => Console.WriteLine(x.ToString()));

// Searching a List<T>
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

// Finding Multiple Items with FindAll()
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

// Dictionary Collections: Dictionary<TKey, TValue>
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

//743

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