using static Thermostat;

class Heater
{
    public Heater(float temp)
    {
        temperature = temp;
    }
    private float temperature { get; set; }
    public void OnTemperatureChanged(object sender, TemperatureArgs e)
    {
        if (e.NewTemperature < temperature)
            Console.WriteLine("Heater: On");
        else
            Console.WriteLine("Heater: Off");
    }
}
class Cooler
{
    public Cooler(float temp)
    {
        temperature = temp;
    }
    private float temperature { get; set; }

    public void OnTemperatureChanged(object sender, TemperatureArgs e)
    {
        if (e.NewTemperature > temperature)
            Console.WriteLine("Cooler: On");
        else
            Console.WriteLine("Cooler: Off");
    }
}

public class Thermostat
{
    public class TemperatureArgs : EventArgs
    {
        public TemperatureArgs(float newTemperature)
        {
            NewTemperature = newTemperature;
        }
        public float NewTemperature { get; set; }
    }

    public delegate void TemperatureChangeHandler(object sender, TemperatureArgs newTemperature);

    public event EventHandler<TemperatureArgs> OnTemperatureChange;

    public float CurrentTemperature
    {
        get
        {
            return _currentTemperature;
        }
        set
        {
            if (value != CurrentTemperature)
            {
                _currentTemperature = value;
                OnTemperatureChange?.Invoke(this, new TemperatureArgs(value));
            }
        }
    }
    private float _currentTemperature { get; set; }
}

class Program
{
    static void Main()
    {
        Thermostat thermostat = new Thermostat();
        Heater heater = new Heater(60);
        Cooler cooler = new Cooler(80);
        thermostat.OnTemperatureChange += heater.OnTemperatureChanged;
        thermostat.OnTemperatureChange += cooler.OnTemperatureChanged;
        thermostat.CurrentTemperature = 30;

    }
}