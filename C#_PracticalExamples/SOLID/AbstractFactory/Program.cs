using AbstractFactory.Factory;

CarFactory audiFactory = new AudiFactory();
CarFactory mercedesFactory = new MercedesFactory();
CarFactory bmwFactory = new BMWFactory();

List<CarFactory> factories = new List<CarFactory>()
{
    audiFactory, mercedesFactory, bmwFactory
};

var combiCars = factories.Select(x => x.CreateCombi());

foreach(var fact in combiCars)
    fact.Name();
