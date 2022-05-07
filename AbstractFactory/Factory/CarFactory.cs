global using AbstractFactory.CarType;

namespace AbstractFactory.Factory;

public abstract class CarFactory
{
    public abstract CombiCar CreateCombi();
    public abstract SedanCar CreateSedan();
    public abstract HatchbackCar CreateHatchback();
    public abstract CoupeCar CreateCoupe();
    public abstract SUVCar CreateSUV();
}