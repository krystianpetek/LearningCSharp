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

// 714  

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
    IEnumerable<string> selection = from word in CSharp.Keywords where word.Contains("*") select $"{word} ";
    Console.WriteLine("Query created");
    foreach (var item in selection)
        Console.Write(item);
}

static void ListingFilesLikeTupleRatherThanFileInfo()
{
    IEnumerable<string> fileNames = Directory.EnumerateFiles("../../../");
    var fileResult = from file in fileNames select new { Name = file, LastWriteTime = File.GetLastWriteTime(file) };
    foreach (var file in fileResult)
        Console.WriteLine($"{file.Name}, {file.LastWriteTime}");

}
static void ListingFilesByFileInfo()
{
    IEnumerable<string> fileNames = Directory.GetFiles("../../../");
    IEnumerable<FileInfo> fileInfos = from file in fileNames /*where new FileInfo(file).Extension == ".cs"*/ select new FileInfo(file);
    foreach (FileInfo fileInfo in fileInfos)
    {
        Console.WriteLine($"{fileInfo.Name} ({fileInfo.LastWriteTime})");
    }
}

// first
static void ListOfKeywordsInCS()
{
    IEnumerable<string> selection = from word in CSharp.readOnlyKeywords where !word.Contains('*') select word;
    foreach (string word in selection)
    {
        Console.Write(word + " ");
    }
}