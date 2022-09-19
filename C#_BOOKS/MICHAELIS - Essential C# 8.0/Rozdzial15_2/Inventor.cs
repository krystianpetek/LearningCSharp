// standard query operators

public class Inventor
{
    public long Id { get; }
    public string Name { get; }
    public string City { get; }
    public string State { get; }
    public string Country { get; }

    public Inventor(string name, string city, string state, string country, int id)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        City = city ?? throw new ArgumentNullException(nameof(city));
        State = state ?? throw new ArgumentNullException(nameof(state));
        Country = country ?? throw new ArgumentNullException(nameof(country));
        Id = id;
    }

    public override string ToString()
    {
        return $"{Name} ({City}, {State})";
    }
};