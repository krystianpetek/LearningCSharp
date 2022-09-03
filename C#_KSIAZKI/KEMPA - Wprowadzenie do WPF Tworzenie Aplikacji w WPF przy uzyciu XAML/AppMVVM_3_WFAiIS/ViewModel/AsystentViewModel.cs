using AppMVVM_3_WFAiIS.Model;
using System.ComponentModel;
using System.Windows.Input;

namespace AppMVVM_3_WFAiIS.ViewModel
{
    public class AsystentViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private AsystentModel asystentModel = new AsystentModel(1000);

        public string Suma
        {
            get { return asystentModel.Suma.ToString(); }
        }

        private ICommand sumuj;
        public ICommand Sumuj
        {
            get
            {
                if (sumuj == null)
                    sumuj = new RelayCommand(
                        (obj) =>
                        {
                            decimal kwota = decimal.Parse((string)obj);
                            asystentModel.DodajKwote(kwota);
                            onPropertyChanged("Suma");
                        },
                        (obj) =>
                        {
                            return czyLancuchKwotyJestPoprawny((string)obj);
                        });

                return sumuj;
            }

        }

        private void onPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private bool czyLancuchKwotyJestPoprawny(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return false;
            bool parsowanie = decimal.TryParse(s, out decimal suma);
            if (!parsowanie)
                return false;

            return asystentModel.CzyKwotaJestPoprawna(suma);
        }
    }
}
