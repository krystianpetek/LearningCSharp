using FactoryMethod;

ICreator[] creators = new ICreator[]
{
    new CreatorProductA(),
    new CreatorProductB()
};

foreach (ICreator creator in creators)
{
    Console.WriteLine(creator);
}