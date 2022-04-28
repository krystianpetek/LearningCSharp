namespace Zdarzenia2
{
    public class CarsComputer
    {
        private int temperature;
        private int pressure;

        public CarsComputer(int t, int p)
        {
            temperature = t;
            pressure = p;
        }

        public int GetPressure()
        {
            return pressure;
        }

        public int GetTemperature()
        {
            return temperature;
        }
    }
}