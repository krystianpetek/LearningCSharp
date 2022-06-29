using Rozdzial16_1;

ListOfKeywordsInCS();
Console.WriteLine("\n");
ListingFilesByFileInfo();
Console.WriteLine("\n");
ListingFilesLikeTupleRatherThanFileInfo();
Console.WriteLine("\n");
DefferedExecutionWithQueryExpressions();
Console.WriteLine("\n");
DefferedExecutionWithQueryExpressionsNextExample();
Console.WriteLine("\n");
FindMonthOldFiles(Directory.GetCurrentDirectory(), "*.*");
Console.WriteLine("\n");
ListByFileSize(Directory.GetCurrentDirectory(), "*.*");
Console.WriteLine("\n");
ListByFileSizeWithLET(Directory.GetCurrentDirectory(), "*.*");
Console.WriteLine("\n");
GroupKeywords();
Console.WriteLine("\n");
GroupKeywordsBetter();
Console.WriteLine("\n");
SequenceOfSequence();
Console.WriteLine("\n");
CartesianProduct();
Console.WriteLine("\n");
ListMemberNames();
Console.WriteLine("\n");
ShowContextualKeywords();
Console.WriteLine("\n");

// query expression translated to Standard query operator
static void ShowContextualKeywords()
{
    IEnumerable<string> selection = CSharp.Keywords.Where(x => x.Contains("*"));

    foreach (var item in selection)
    {
        Console.Write($"{item}, ");
    }
}

static void ListMemberNames()
{
    IEnumerable<string> enumerableMethodNames = (from method in typeof(Enumerable).GetMembers(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public) orderby method.Name select method.Name).Distinct();
    foreach (string method in enumerableMethodNames)
    {
        Console.Write($"{method},");
    }
}

// cartesian product
static void CartesianProduct()
{
    var numbers = new[] { 1, 2, 3 };
    var products = from word in CSharp.Keywords
                   from number in numbers
                   select (word, number);

    foreach (var product in products)
    {
        Console.Write(product.word + product.number + " ");
    }
}
// flattening sequence of sequence using multiple FROM
static void SequenceOfSequence()
{
    var selection = from word in CSharp.Keywords from character in word select character;

    foreach (var character in selection)
        Console.Write($"{character} ");
}

// GroupKeywordsBetter using clause INTO
static void usingIntoClause()
{
    IEnumerable<(bool IsContextualKeywords, IGrouping<bool, string> items)> selection =
        from word in CSharp.Keywords
        group word by word.Contains("*")
        into groups
        select
        (
            IsContextualKeyword: groups.Key,
            Items: groups
        );
    ShowBetterKeyword(selection);
}

// selecting a tuple following the group clause
static void GroupKeywordsBetter()
{
    IEnumerable<IGrouping<bool, string>> keywordGroups = from word in CSharp.Keywords group word by word.Contains("*");

    IEnumerable<(bool IsContextualKeyword, IGrouping<bool, string> items)> selection =
        from groups in keywordGroups
        select
        (
            IsContextualKeyword: groups.Key,
            Items: groups
        );
    ShowBetterKeyword(selection);
}

// grouping together keywords
static void GroupKeywords()
{
    IEnumerable<IGrouping<bool, string>> selection = from word in CSharp.Keywords group word by word.Contains("*");

    foreach (IGrouping<bool, string> wordGroup in selection)
    {
        Console.WriteLine(Environment.NewLine + "{0}:", wordGroup.Key ? "Contextual Keywords" : "Keywords");
        foreach (string keyword in wordGroup)
        {
            Console.Write(" " + (wordGroup.Key ? keyword.Replace("*", null) : keyword));
        }
        Console.WriteLine();
    }
}

// declaring next variable using LET in Linq
static void ListByFileSizeWithLET(string rootDirectory, string stringPattern)
{
    IEnumerable<FileInfo> fileInfos = from fileName in Directory.EnumerateFiles(rootDirectory, stringPattern)
                                      let file = new FileInfo(fileName)
                                      orderby file.Length descending, fileName
                                      select file;

    foreach (FileInfo file in fileInfos)
    {
        string relativePath = file.FullName.Substring(Environment.CurrentDirectory.Length);
        Console.WriteLine($".{relativePath}({file.Length})");
    }
}


// sorting
static void ListByFileSize(string rootDirectory, string stringPattern)
{
    IEnumerable<string> fileNames = from fileName in Directory.EnumerateFiles(rootDirectory, stringPattern)
                                    orderby (new FileInfo(fileName)).Length descending, fileName
                                    select fileName;

    foreach (string fileName in fileNames)
    {
        Console.WriteLine(fileName);
    }
}

// query expression filtering using where
void FindMonthOldFiles(string root, string searchPattern)
{
    IEnumerable<FileInfo> files = from fileName in Directory.EnumerateFiles(root, searchPattern) where File.GetLastWriteTime(fileName) < DateTime.Now.AddDays(-1) /*AddMonth(-1)*/ select new FileInfo(fileName);
    foreach (var file in files)
    {
        var relativePath = file.FullName.Substring(Environment.CurrentDirectory.Length);
        Console.WriteLine($".{relativePath} ({file.LastWriteTime})");
    }
}

void DefferedExecutionWithQueryExpressionsNextExample()
{
    int delegateInvocations = 0;
    string func(string text)
    {
        delegateInvocations++;
        return text;
    }

    IEnumerable<string> selection = from keyword in CSharp.Keywords where keyword.Contains("*") select func(keyword);
    Console.WriteLine(
    $"1. delegateInvocations={delegateInvocations}");
    // Executing count should invoke func once for
    // each item selected
    Console.WriteLine(
    $"2. Contextual keyword count={selection.Count()}");
    Console.WriteLine(
    $"3. delegateInvocations={delegateInvocations}");
    // Executing count should invoke func once for
    // each item selected
    Console.WriteLine(
    $"4. Contextual keyword count={selection.Count()}");
    Console.WriteLine(
    $"5. delegateInvocations={delegateInvocations}");
    // Cache the value so future counts will not trigger
    // another invocation of the query
    List<string> selectionCache = selection.ToList();
    Console.WriteLine(
    $"6. delegateInvocations={delegateInvocations}");
    // Retrieve the count from the cached collection
    Console.WriteLine(
    $"7. selectionCache count={selectionCache.Count()}");
    Console.WriteLine(
    $"8. delegateInvocations={delegateInvocations}");
}

void DefferedExecutionWithQueryExpressions()
{
    IEnumerable<string> selection = from word in CSharp.Keywords where IsKeyword(word) select $"{word}";
    Console.WriteLine("Query created");
    foreach (var keyword in selection)
        Console.Write(keyword);
}

static bool IsKeyword(string word)
{
    if (word.Contains("*"))
    {
        Console.Write(" ");
        return true;
    }
    return false;
}

static void ListingFilesLikeTupleRatherThanFileInfo()
{
    IEnumerable<string> fileNames = Directory.EnumerateFiles("../../../");
    var fileResult = from file in fileNames select new { Name = file, LastWriteTime = File.GetLastWriteTime(file) };
    var fileResultOtherMethod = from file in fileNames select (Name: file, LastWriteTime: File.GetLastWriteTime(file));

    foreach (var file in fileResult)
        Console.WriteLine($"{file.Name}, {file.LastWriteTime}");

}

// second - projection query expression
static void ListingFilesByFileInfo()
{
    IEnumerable<string> fileNames = Directory.GetFiles("../../../");
    IEnumerable<FileInfo> fileInfos = from file in fileNames where new FileInfo(file).Extension == ".cs" select new FileInfo(file);
    foreach (FileInfo fileInfo in fileInfos)
    {
        Console.WriteLine($"{fileInfo.Name} ({fileInfo.LastWriteTime})");
    }
}

// first - simple query expression
static void ListOfKeywordsInCS()
{
    IEnumerable<string> selection = from word in CSharp.readOnlyKeywords where !word.Contains('*') select word;

    foreach (string word in selection)
    {
        Console.Write(word + " ");
    }
}

static void ShowBetterKeyword(IEnumerable<(bool IsContextualKeyword, IGrouping<bool, string> items)> selection)
{
    foreach ((bool isContextualKeyword, IGrouping<bool, string> items) in selection)
    {
        Console.WriteLine(Environment.NewLine + "{0}:", isContextualKeyword ? "Contextual keywords" : "Keywords");
        foreach (var keyword in items)
        {
            Console.Write(" " + keyword.Replace("*", null));
        }
        Console.WriteLine();
    }
}