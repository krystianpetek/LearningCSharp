using System;
using System.Windows;
using System.Windows.Input;

namespace WpfApp1
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

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            btnStart.Visibility = Visibility.Hidden;
            btnStart.Opacity = 0.5;
            MessageBox.Show("Witaj, świecie!");
            btnStart.Opacity = 1;
            btnStart.Visibility = Visibility.Visible;
            btnStart.IsEnabled = false;
        }

        private void btnTime_MouseEnter(object sender, MouseEventArgs e)
        {
            DateTime date = DateTime.Now;
            btnTime.Content = date.ToString("T");
        }

        private void btnTime_MouseLeave(object sender, MouseEventArgs e)
        {
            btnTime.Content = "Czas";
        }

        private void btnWlaczStart_Click(object sender, RoutedEventArgs e)
        {
            btnStart.IsEnabled = true;
        }

        private void btnPodwyzkaTak_MouseEnter(object sender, MouseEventArgs e)
        {
            var marginTemp = btnPodwyzkaTak.Margin;
            btnPodwyzkaTak.Margin = btnPodwyzkaNie.Margin;
            btnPodwyzkaNie.Margin = marginTemp;
        }
    }
}

// frameworkelement i frameworkcontentelement