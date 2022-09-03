using AbstractFactory.Audi;

namespace AbstractFactory.Factory;

public class MercedesFactory : CarFactory
{
    public override CombiCar CreateCombi()
    {
        return new MercedesCombi();
    }

    public override SedanCar CreateSedan()
    {
        return new MercedesSedan();
    }

    public override HatchbackCar CreateHatchback()
    {
        return new MercedesHatchback();
    }

    public override CoupeCar CreateCoupe()
    {
        return new MercedesCoupe();
    }

    public override SUVCar CreateSUV()
    {
        return new MercedesSUV();
    }
}