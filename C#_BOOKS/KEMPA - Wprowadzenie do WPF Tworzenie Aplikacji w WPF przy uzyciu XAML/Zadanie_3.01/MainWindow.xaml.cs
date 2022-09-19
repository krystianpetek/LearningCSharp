using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Zadanie_3._01
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

        private void lblBok_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            txtBok.Focus();
        }

        private void txtBok_TextChanged(object sender, TextChangedEventArgs e)
        {
            var wartoscBok = txtBok.Text;

            if (wartoscBok == string.Empty)
            {
                lblKomunikat.Content = "Wpisz wymiar bloku";
                txtPole.Text = "";
                txtObwod.Text = "";
                return;
            }
            wartoscBok = wartoscBok.Replace('.', ',');

            bool prawidlowa = double.TryParse(wartoscBok, out double wejscie);

            if (!prawidlowa)
            {
                lblKomunikat.Content = "Podaj wartość liczbową";
                txtPole.Text = "";
                txtObwod.Text = "";
                return;
            }

            if (wejscie < 0)
            {
                lblKomunikat.Content = "Podaj wartość dodatnią";
                txtPole.Text = "";
                txtObwod.Text = "";
                return;
            }

            lblKomunikat.Content = "";
            txtPole.Text = $"{wejscie * wejscie:F2}";
            txtObwod.Text = $"{(wejscie * 4):F2}";
        }

        private void btnWyczysc_Click(object sender, RoutedEventArgs e)
        {
            txtBok.Text = "";
        }
    }
}