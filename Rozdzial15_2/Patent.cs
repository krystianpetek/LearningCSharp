// standard query operators

public class Patent
{
    public string Title { get; }
    public string YearOfPublication { get; }
    public string? ApplicationNumber { get; set; }
    public long[] InventorIds { get; }

    public Patent(string title, string yearOfPublication, long[] inventorIds)
    {
        Title = title ?? throw new ArgumentNullException(nameof(title));
        YearOfPublication = yearOfPublication ?? throw new ArgumentNullException(nameof(yearOfPublication));
        InventorIds = inventorIds ?? throw new ArgumentNullException(nameof(inventorIds));
    }

    public override string ToString()
    {
        return $"{Title} ({YearOfPublication})";
    }
};