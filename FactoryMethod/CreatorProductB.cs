namespace FactoryMethod;

public class CreatorProductB : ICreator
{
    public IProduct FactoryMethod()
    {
        return new ProductB();
    }
}