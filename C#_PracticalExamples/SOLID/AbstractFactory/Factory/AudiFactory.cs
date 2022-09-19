using AbstractFactory.Audi;

namespace AbstractFactory.Factory;

public class AudiFactory : CarFactory
{
    public override CombiCar CreateCombi()
    {
        return new AudiCombi();
    }

    public override SedanCar CreateSedan()
    {
        return new AudiSedan();
    }

    public override HatchbackCar CreateHatchback()
    {
        return new AudiHatchback();
    }

    public override CoupeCar CreateCoupe()
    {
        return new AudiCoupe();
    }

    public override SUVCar CreateSUV()
    {
        return new AudiSUV();
    }
}