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

namespace leftSliderNavBar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static bool expandedPanel = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void expandPanel_Click(object sender, RoutedEventArgs e)
        {
            if (!expandedPanel)
            {
                expandedPanel = true;
                navPanel.Width = 200;
                homeLabelInPanel.Width = 170;
                home2LabelInPanel.Width = 170;
            }
            else
            {
                expandedPanel = false;
                navPanel.Width = 80;
                homeLabelInPanel.Width = 50;
                home2LabelInPanel.Width = 50;
            }
        }
    }
}
