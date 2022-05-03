using AppMVVM_WFAiIS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppMVVM_WFAiIS.ViewModel
{
    internal class ViewModelMPAM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
    
        private void onPropertyChanged(string nameOfProperty)
        {
            if(PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(nameOfProperty));
        }

        private ModelMPAM model = FileHelper.Read();



        public double ValueOfMySlider
        {
            get
            {
                return model.ValueOfMySlider;
            }
            set
            {
                model.ValueOfMySlider = value;
                onPropertyChanged(nameof(ValueOfMySlider));
                model.Save();
            }
        }

        private ICommand reset;
        public ICommand ResetVM
        {
            get 
            { if (reset == null)
                    reset = new RelayCommand(
                        (o) =>
                        {
                            model.Reset();
                            model.Save();
                            onPropertyChanged(nameof(ValueOfMySlider));
                        },
                        (o) =>
                        {
                            return model.ValueOfMySlider > 0;
                        }
                        );
                return reset;
            }
        }
    }
}
