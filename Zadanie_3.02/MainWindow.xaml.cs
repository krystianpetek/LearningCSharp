using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Zadanie_3._02
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

        private void btnRysuj_Click(object sender, RoutedEventArgs e)
        {
            string kolor = cmbKolor.Text;
            if (chkbxPrzezroczysty.IsChecked.Value)
                rectRysuj.Opacity = 0.5;
            else
                rectRysuj.Opacity = 1;

            switch(kolor)
            {
                case "Black":
                    rectRysuj.Fill = System.Windows.Media.Brushes.Black;
                    break;
                case "Red":
                    rectRysuj.Fill = System.Windows.Media.Brushes.Red;
                    break;
                case "Yellow":
                    rectRysuj.Fill = System.Windows.Media.Brushes.Yellow;
                    break;
                case "Green":
                    rectRysuj.Fill = System.Windows.Media.Brushes.Green;
                    break;
                case "Blue":
                    rectRysuj.Fill = System.Windows.Media.Brushes.Blue;
                    break;
            }
            if (txtBok.Text == "")
            {
                rectRysuj.Width = 0;
                rectRysuj.Height = 0;
                rectRysuj.Fill = rectRysuj.Fill = System.Windows.Media.Brushes.White;
                return;
            }
            double.TryParse(txtBok.Text,out double wartosc);
            if(wartosc > 0)
            {
                if(wartosc > 400)
                {
                    rectRysuj.Width = 400;
                    rectRysuj.Height = 400;
                    return;
                }
                rectRysuj.Width = wartosc;
                rectRysuj.Height = wartosc;
            }
        }
    }
}