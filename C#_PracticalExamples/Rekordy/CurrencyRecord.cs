//public record CurrencyRecord
//{
//    public int Value { get; set; }
//    public string Name { get; set; }
//    public override string ToString()
//    {
//        return $"{Name} {Value}";
//    }
//}

// można zapisać struct lub class
public record class CurrencyRecord(string Name, decimal Value, string SomeValue) : BaseCurrencyRecord(SomeValue), IDisposable
{
    public void Dispose()
    {
        throw new NotImplementedException();
    }
}

public record CurrencyRecord<T>(string Name, decimal Value, string SomeValue) : BaseCurrencyRecord(SomeValue);

