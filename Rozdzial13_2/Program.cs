using System.Diagnostics;

IEnumerable<Process> processes = Process.GetProcesses().Where(process => { return process.WorkingSet64 > 1000000000; });
foreach (Process process in processes)
    Console.WriteLine(process);

Func<string> getUserInput = () =>
{
    string input;
    do
    {
        input = Console.ReadLine();
    }
    while (input.Trim().Length == 0);
    return input;
};

var userInput = getUserInput();


// anonymous methods

var anonymousMethod = delegate (int first, int second)
{
    return first < second;
};
Console.WriteLine(anonymousMethod(5, 10));

// contravariance
Action<object> generalContravarianceDelegate =
    (object data) =>
    {
        Console.WriteLine(data);
    };
Action<string> detailedContravarianceDelgate = generalContravarianceDelegate;

// covariance
Func<string> detailedCovarianceDelegate =
    () => Console.ReadLine();
Func<object> generalCovarianceDelegate = detailedCovarianceDelegate;

// combined covariance and contravariance
Func<object, string> function =
    (object data) => data.ToString();
Func<string, object> functionReverse = function;


// Accidentally Capturing Loop Variables, solved
var items = new string[] { "Moe", "Larry", "Curly" };
var actions = new List<Action>();

foreach (string item in items)
{
    string _item = item; // w cs 5.0 zostało naprawione, przed 5.0 trzeba uzyc przypisania do wewnetrznej wartosci
    actions.Add(() => Console.WriteLine(_item));
}

foreach (Action action in actions)
{
    action();
}

