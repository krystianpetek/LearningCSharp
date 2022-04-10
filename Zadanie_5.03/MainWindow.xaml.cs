using System;
using System.Windows;

namespace Zadanie_5._03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PrzygotujWiazanie();
        }

        private Produkt p1 = null;

        private void PrzygotujWiazanie()
        {
            p1 = new Produkt("DZ-10", "długopis żelowy", 132, "Katowice 1");
            gridProdukt.DataContext = p1;
        }

        private void btnPotwierdz_Click(object sender, RoutedEventArgs e)
        {
            string tekst = string.Format("{0}{1}{2}", "Wprowadzono dane:", Environment.NewLine, p1.ToString());
            MessageBox.Show(tekst);
        }
    }
}