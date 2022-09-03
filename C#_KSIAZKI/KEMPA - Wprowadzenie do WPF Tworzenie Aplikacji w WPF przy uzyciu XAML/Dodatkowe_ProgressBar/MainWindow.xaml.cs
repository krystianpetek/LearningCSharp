using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Dodatkowe_ProgressBar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Slider_LostMouseCapture(object sender, MouseEventArgs e)
        {
            await SuwakTask();
            Slider.IsEnabled = true;
        }

        private async Task SuwakTask()
        {
            var slider = (int)Slider.Value;
            wartoscZadanaVal.Content = slider;
            var progressBar = (int)ProgressBar.Value;

            Slider.IsEnabled = false;
            await Task.Delay(200);
            if (slider > progressBar)
            {
                for (int i = slider; i > progressBar; i--)
                {
                    await Task.Delay(1);
                    ProgressBar.Value++;
                    wartoscAktualnaVal.Content = ProgressBar.Value;
                }
            }
            else
            {
                for (int i = slider; i < progressBar; i++)
                {
                    await Task.Delay(1);
                    ProgressBar.Value--;
                    wartoscAktualnaVal.Content = ProgressBar.Value;
                }
            }
        }

        // https://stackoverflow.com/questions/15599884/how-to-put-delay-before-doing-an-operation-in-wpf
    }
}