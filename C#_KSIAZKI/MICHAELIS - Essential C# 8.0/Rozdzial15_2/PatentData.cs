public static class PatentData
{
    public static readonly Inventor[] Inventors = new Inventor[]
    {
        new Inventor("Benjamin Franklin", "Philadelphia", "PA", "USA", 1),
        new Inventor("Orville Wright", "Kitty Hawk", "NC", "USA", 2),
        new Inventor("Wilbur Wright", "Kitty Hawk", "NC", "USA", 3),
        new Inventor("Samuel Morse", "New York", "NY", "USA", 4),
        new Inventor("George Stephenson", "Wylam", "Northumberland", "UK", 5),
        new Inventor("John Michaelis", "Chicago", "IL", "USA", 6),
        new Inventor("Mary Phelps Jacob", "New York", "NY", "USA", 7)
    };

    public static readonly Patent[] Patents = new Patent[]
    {
        new Patent("Bifocals","1784", inventorIds: new long[] { 1 }),
        new Patent("Phonograph", "1877", inventorIds: new long[] { 1 }),
        new Patent("Kinetoscope", "1888", inventorIds: new long[] { 1 }),
        new Patent("Electrical Telegraph", "1837", inventorIds: new long[] { 4 }),
        new Patent("Flying Machine", "1903", inventorIds: new long[] { 2, 3 }),
        new Patent("Steam Locomotive", "1815", inventorIds: new long[] { 5 }),
        new Patent("Droplet Deposition Apparatus", "1989", inventorIds: new long[] { 6 }),
        new Patent("Backless Brassiere", "1914", inventorIds: new long[] { 7 })
    };
}