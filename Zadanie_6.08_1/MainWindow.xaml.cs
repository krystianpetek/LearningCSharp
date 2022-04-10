using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Zadanie_6._08_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Produkt> ListaProduktow = null;

        public MainWindow()
        {
            InitializeComponent();
            PrzygotujWiazanie();
        }

        private void PrzygotujWiazanie()
        {
            ListaProduktow = new ObservableCollection<Produkt>();
            ListaProduktow.Add(new Produkt("01-11", "ołówek", 8, "Katowice 1"));
            ListaProduktow.Add(new Produkt("PW-20", "pióro wieczne", 75, "Katowice 2"));
            ListaProduktow.Add(new Produkt("DZ-10", "długopis żelowy", 1121, "Katowice 1"));
            ListaProduktow.Add(new Produkt("DZ-12", "długopis kulkowy", 280, "Katowice 2"));

            var query = from x in ListaProduktow orderby x.Magazyn, x.Nazwa select x;
            lstProdukty.ItemsSource = query;
        }

        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            var query = from x in ListaProduktow where x.Nazwa.Contains(txtFilter.Text, StringComparison.OrdinalIgnoreCase) orderby x.Magazyn, x.Nazwa select x;
            lstProdukty.ItemsSource = query;
        }

        private void lstProdukty_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Window1 okno1 = new(this);
            okno1.ShowDialog();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            var produkt = lstProdukty.SelectedItem as Produkt;
            if (produkt != null)
            {
                MessageBoxResult odpowiedz = MessageBox.Show("Czy wykasować produkt: " + produkt.ToString() + "?", "Pytanie", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (odpowiedz == MessageBoxResult.Yes)
                {
                    ListaProduktow.Remove(produkt);
                    var query = from x in ListaProduktow where x.Nazwa.Contains(txtFilter.Text, StringComparison.OrdinalIgnoreCase) orderby x.Magazyn, x.Nazwa select x;
                    lstProdukty.ItemsSource = query;
                }
            }
        }
    }
}
