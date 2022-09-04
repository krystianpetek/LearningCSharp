// standard query operators

Console.WriteLine("Patents: ");
IEnumerable<Patent> patents = PatentData.Patents;
Print(patents);
Console.WriteLine();

Console.WriteLine("Inventors: ");
IEnumerable<Inventor> inventors = PatentData.Inventors;
Print(inventors);

static void Print<T>(IEnumerable<T> items)
{
    foreach (T item in items)
    {
        Console.WriteLine("\t" + item);
    }
}

// filtering with where()
Console.WriteLine("\nFiltering patents, whose YearOfPublication is between 1800 - 1899 using .WHERE()");
IEnumerable<Patent> patentsOf1800 = patents.Where(patent => patent.YearOfPublication.StartsWith("18"));

// projecting with Select()
Console.WriteLine("Projecting above patents using .SELECT()");
IEnumerable<string> items = patentsOf1800.Select(patent => patent.ToString());
Print(items);

// projection to Tuple\
Console.WriteLine("\nProjecting file details using .SELECT() like Tuple");
IEnumerable<string> fileList = Directory.EnumerateFiles("../../../", "*.*");
IEnumerable<(string FileName, long Size)> fileDetails = fileList.Select(
    file =>
    {
        FileInfo fileInfo = new FileInfo(file);
        return (FileName: fileInfo.Name.ToString(), Size: fileInfo.Length);
    });
Print(fileDetails);

// Running linq queries in parallel
Console.WriteLine("\nProjecting file details using .AsParallel().SELECT() like Tuple");
var itemsParallel = fileList.AsParallel().Select(
    file =>
    {
        FileInfo fileInfo = new FileInfo(file);
        return new
        {
            FileName = fileInfo.Name,
            Size = fileInfo.Length
        };
    });
Print(itemsParallel);

// counting elements with Count()
Console.WriteLine("\nCounting elements with .Count()");
Console.WriteLine($"\tPatent count: {patents.Count()}");
Console.WriteLine($"\tPatent count in 1800s: {patents.Count(patent => patent.YearOfPublication.StartsWith("18"))}");

// if you can check whether is any items in collection, you can better use .Any()

// deferred execution
bool result;
patents = patents.Where(
patent =>
{
    if (result =
    patent.YearOfPublication.StartsWith("18"))
    {
        // Side effects like this in a predicate
        // are used here to demonstrate a
        // principle and should generally be
        // avoided
        Console.WriteLine("\t" + patent);
    }
    return result;
});

IEnumerable<Patent> itemsToSort;
// Sorting with .OrderBy() and next .ThenBy()
Console.WriteLine("\nSorting with .OrderBy() and next .ThenBy()");
Patent[] patentsToSort = PatentData.Patents;
itemsToSort = patentsToSort.OrderBy(patent => patent.YearOfPublication).ThenBy(patent => patent.Title);
Print(itemsToSort);

// Sorting with .OrderByDescending() and next .ThenByDescending()
Console.WriteLine("\nSorting with .OrderByDescending() and next .ThenByDescending()");
itemsToSort = patentsToSort
    .OrderByDescending(patent => patent.YearOfPublication)
    .ThenByDescending(patent => patent.Title);
Print(itemsToSort);

// JOIN operator