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

        private void lblPole_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            txtPole.Focus();
        }

        private void lblObwod_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            txtObwod.Focus();
        }

    }
}
