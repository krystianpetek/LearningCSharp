using AppMVVM_2_WFAiIS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppMVVM_2_WFAiIS.ViewModel
{
    public class ViewModelApp2 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private TextModel textModel = new TextModel();

        private void onPropertyChanged(string value)
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(value));

        }

        private ICommand reset;
        public ICommand Reset
        {
            get
            {
                if (reset == null)
                    return new RelayCommand(
                        o =>
                        {
                            textModel.CleanText();
                            onPropertyChanged(nameof(Text));
                        },
                        o =>
                        {
                            return Text.Length > 0;
                        }
                        );

                return reset;
            }
        }

        public string Text
        {
            get
            {
                return textModel.Text;
            }
            set
            { 
                textModel.Text = value;
                onPropertyChanged(nameof(Text));
            }
        }
    }
}
