using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace Zadanie_11._03
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

        private void Zapisz_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBox.Show(this, "Czy chcesz zapisać zmiany?", "Zapisz", MessageBoxButton.OKCancel, MessageBoxImage.Warning,MessageBoxResult.OK);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBox.Show(this, "Czy chcesz zapisać zmiany?", "Zatwierdź", MessageBoxButton.OKCancel, MessageBoxImage.Warning, MessageBoxResult.OK);

        }
    }
}
