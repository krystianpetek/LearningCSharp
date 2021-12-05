using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SZRefleksje
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void Button_Click2(object sender, RoutedEventArgs e)
        {
            Przycisk1.IsEnabled = false;
            Przycisk1.Visibility = Visibility.Collapsed;     
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            Przycisk1.Visibility = Visibility;
            Przycisk1.IsEnabled = true;
        }

        private void Button_Click4(object sender, RoutedEventArgs e)
        {

        }
    }
}
