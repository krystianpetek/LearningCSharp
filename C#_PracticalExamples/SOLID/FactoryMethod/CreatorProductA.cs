namespace FactoryMethod;

public class CreatorProductA : ICreator
{
    public IProduct FactoryMethod()
    {
        return new ProductA();
    }
}