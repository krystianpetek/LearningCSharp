// initializate lists with collection initializer
List<string> sevenWorldBlunders = new List<string>()
{
    "Wealth without work",
    "Pleasure without conscience",
    "Knowledge without character",
    "Commerce without morality",
    "Science without humanity",
    "Worship without sacrifice",
    "Politics without principle"
};

static void Print<T>(IEnumerable<T> list)
{
    foreach (T item in list)
    {
        Console.WriteLine(item);
    }
}
Print(sevenWorldBlunders);

// initialize directory<> with collection initializer

Dictionary<string, ConsoleColor> colorMap = new Dictionary<string, ConsoleColor>
{
    ["Error"] = ConsoleColor.Red,
    ["Warning"] = ConsoleColor.Yellow,
    ["Information"] = ConsoleColor.Green,
    ["Verbose"] = ConsoleColor.White
};

// implementation a foreach loop on stack
Stack<int> stack = new Stack<int>(new List<int>() { 1, 3, 2, 5, 23, 3, 6 });
int number;
IDisposable disposable;

using (Stack<int>.Enumerator enumerator = stack.GetEnumerator())
{
    while (enumerator.MoveNext())
    {
        number = enumerator.Current;
        Console.WriteLine(number);
    }
}