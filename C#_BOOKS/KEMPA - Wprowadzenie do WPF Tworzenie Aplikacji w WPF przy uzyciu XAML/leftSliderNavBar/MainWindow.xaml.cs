using System.Windows;

namespace leftSliderNavBar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static bool expandedPanel = false;

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