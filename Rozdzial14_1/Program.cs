
class Cooler
{
    public Cooler(float temperature)
    {
        _temperature = temperature;
    }
    private float _temperature { get; set; }
    public void OnTemperatureChanged(float newTemperature)
    {
        if(newTemperature > _temperature)
            Console.WriteLine("Cooler: On");
        else
            Console.WriteLine("Cooler: Off");
    }
    
}
class Heater
{
    public Heater(float temperature)
    {
        _temperature = temperature;
    }
    private float _temperature { get; set; }

    public void OnTemperatureChanged(float newTemperature)
    {
        if (newTemperature < _temperature)
            Console.WriteLine("Heater: On");
        else
            Console.WriteLine("Heater: Off");
    }
}

public class Thermostat
{
    public Action<float>? OnTemperatureChange { get; set; }
    private float _CurrentTemperature { get; set; }
    public float CurrentTemperature
    {
        get { return _CurrentTemperature; }
        set
        {
            if (value != CurrentTemperature)
            {
                _CurrentTemperature = value;

                OnTemperatureChange?.Invoke(value);
            }
        }
    }
}

public class Program
{
    static void Main()
    {

        Thermostat thermostat = new Thermostat();
        Cooler cooler = new Cooler(80);
        Heater heater = new Heater(60);
        string? temperature;

        thermostat.OnTemperatureChange += heater.OnTemperatureChanged;
        thermostat.OnTemperatureChange += cooler.OnTemperatureChanged;

        Console.WriteLine("Enter temperature: ");
        temperature = Console.ReadLine();
        thermostat.CurrentTemperature = int.Parse(temperature);
    }
}