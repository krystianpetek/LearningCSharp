// CAlliung selectMany()
Console.WriteLine("Calling selectMany() method");

(string Team, string[] Players)[] worldCup2006Finalists = new[]
{
    (
        "France",
        new string[]
        {
            "Fabien Barthez", "Gregory Coupet",
            "Mickael Landreau", "Eric Abidal",
            "Jean-Alain Boumsong", "Pascal Chimbonda",
            "William Gallas", "Gael Givet",
            "Willy Sagnol", "Mikael Silvestre",
            "Lilian Thuram", "Vikash Dhorasoo",
            "Alou Diarra", "Claude Makelele",
            "Florent Malouda", "Patrick Vieira",
            "Zinedine Zidane", "Djibril Cisse",
            "Thierry Henry", "Franck Ribery",
            "Louis Saha", "David Trezeguet",
            "Sylvain Wiltord"
        }
    ),
    (
        "Italy",
        new string[]
        {
            "Gianluigi Buffon", "Angelo Peruzzi",
            "Marco Amelia", "Cristian Zaccardo",
            "Alessandro Nesta", "Gianluca Zambrotta",
            "Fabio Cannavaro", "Marco Materazzi",
            "Fabio Grosso", "Massimo Oddo",
            "Andrea Barzagli", "Andrea Pirlo",
            "Gennaro Gattuso", "Daniele De Rossi",
            "Mauro Camoranesi", "Simone Perrotta",
            "Simone Barone", "Luca Toni",
            "Alessandro Del Piero", "Francesco Totti",
            "Alberto Gilardino", "Filippo Inzaghi",
            "Vincenzo Iaquinta",
        }
    )
};

Console.WriteLine("List of players: ");
IEnumerable<string> players = worldCup2006Finalists.SelectMany(team => team.Players);
foreach (var item in players)
    Console.WriteLine(item);

Console.WriteLine("\nOther random action using LINQ method on random object");
IEnumerable<object> stuff = new object[] { new object(), 1, 3, 5, 7, 9, "\"things\"", Guid.NewGuid() };
Print("Stuff {0}", stuff);

IEnumerable<int> even = new int[] { 0, 2, 4, 6, 8 };
Print("Even integers: {0}", even);

IEnumerable<int> odd = stuff.OfType<int>();
Print("Odd integers: {0}", odd);

IEnumerable<int> numbers = even.Union(odd);
Print("Union of odd and even: {0}", numbers);

Print("Union with even: {0}", numbers.Union(even));
Print("Concat with odd: {0}", numbers.Concat(odd));
Print("Intersection with even: {0}",
numbers.Intersect(even));
Print("Distinct: {0}", numbers.Concat(odd).Distinct());

if (!numbers.SequenceEqual(
numbers.Concat(odd).Distinct()))
{
    throw new Exception("Unexpectedly unequal");
}
else
{
    Console.WriteLine(
    @"Collection ""SequenceEquals""" +
    " numbers.Concat(odd).Distinct())");
}
Print("Reverse: {0}", numbers.Reverse());
PrintPrimitive("Average: {0}", numbers.Average());
PrintPrimitive("Sum: {0}", numbers.Sum());
PrintPrimitive("Max: {0}", numbers.Max());
PrintPrimitive("Min: {0}", numbers.Min());

static void Print<T>(string format, IEnumerable<T> items) where T : notnull => Console.WriteLine(format, string.Join(", ", items));
static void PrintPrimitive(string format, double item) => Console.WriteLine(format, item);


// anonymous type
Console.WriteLine();
IEnumerable<string> fileList = Directory.EnumerateFiles("../../../");
var items = fileList.Select(file =>
{
    FileInfo fileInfo = new FileInfo(file);
    return new
    {
        FileName = fileInfo.Name,
        Size = fileInfo.Length
    };
});

foreach(var item in items)
    Console.WriteLine(item);