//var currency1 = new CurrencyRecord()
//{
//    Name = "USD",
//    Value = 10
//};

//var currency2 = new CurrencyRecord()
//{
//    Name = "USD",
//    Value = 10
//};

var currency1 = new CurrencyRecord("USD", 10, "SomeValue");
var currency2 = new CurrencyRecord("USD", 10, "SomeValue");

Console.WriteLine(currency1);
Console.WriteLine(currency2);
Console.WriteLine($"currency1 == currency2: {currency1 == currency2}");
Console.WriteLine($"object.ReferenceEquals(currency1, currency2): {object.ReferenceEquals(currency1, currency2)}");

currency2 = currency1;
Console.WriteLine();
Console.WriteLine(currency1);
Console.WriteLine(currency2);
Console.WriteLine($"currency1 == currency2: {currency1 == currency2}");
Console.WriteLine($"object.ReferenceEquals(currency1, currency2): {object.ReferenceEquals(currency1, currency2)}");

// clone records
currency2 = currency1 with { };
Console.WriteLine();
Console.WriteLine(currency1);
Console.WriteLine(currency2);
Console.WriteLine($"currency1 == currency2: {currency1 == currency2}");
Console.WriteLine($"object.ReferenceEquals(currency1, currency2): {object.ReferenceEquals(currency1, currency2)}");

 // clone records with change value of record until initializate
currency2 = currency1 with { Value = 20 };
Console.WriteLine();
Console.WriteLine(currency1);
Console.WriteLine(currency2);
Console.WriteLine($"currency1 == currency2: {currency1 == currency2}");
Console.WriteLine($"object.ReferenceEquals(currency1, currency2): {object.ReferenceEquals(currency1, currency2)}");

var (name, value, _) = currency1;

// https://sharplab.io/

