using AbstractFactory.Audi;
using AbstractFactory.BMW;

namespace AbstractFactory.Factory;

public class BMWFactory : CarFactory
{
    public override CombiCar CreateCombi()
    {
        return new BMWCombi();
    }

    public override SedanCar CreateSedan()
    {
        return new BMWSedan();
    }

    public override HatchbackCar CreateHatchback()
    {
        return new BMWHatchback();
    }

    public override CoupeCar CreateCoupe()
    {
        return new BMWCoupe();
    }

    public override SUVCar CreateSUV()
    {
        return new BMWSUV();
    }
}