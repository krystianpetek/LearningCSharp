namespace Zdarzenia2
{
    public class DelegateOnBoardComputer
    {
        public delegate void CarsComputerHandler(string info);

        public event CarsComputerHandler CarsComputerEventLog;

        public void LogProcess()
        {
            string information = "ok";
            CarsComputer carsComputer = new CarsComputer(80, 12);
            int t = carsComputer.GetTemperature();
            int p = carsComputer.GetPressure();

            if (t > 70 || p > 15)
                information = "Dokonaj dokładnego przeglądu!";

            OnCarsComputerEventLog($"Zapisywanie informacji: \n");
            OnCarsComputerEventLog($"Temperatura: {t} | Ciśnienie: {p}");
            OnCarsComputerEventLog($"Informacja: {information}");
        }

        protected void OnCarsComputerEventLog(string info)
        {
            if (CarsComputerEventLog != null)
            {
                CarsComputerEventLog(info);
            }
        }
    }
}