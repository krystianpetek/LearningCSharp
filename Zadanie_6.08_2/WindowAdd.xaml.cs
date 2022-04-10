using System;
using System.Linq;
using System.Windows;

namespace Zadanie_6._08_2
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class WindowAdd : Window
    {
        private MainWindow mainWindow;
        public WindowAdd()
        {
            InitializeComponent();
        }
        public WindowAdd(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void btnPotwierdz_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(liczbaSztuk.Text, out int liczba);
            Produkt produkt = new Produkt("AA-00", "", 0, "");
            produkt.Symbol = symbol.Text;
            produkt.Nazwa = nazwa.Text;
            produkt.LiczbaSztuk = liczba;
            produkt.Magazyn = magazyn.Text;

            if (produkt.Nazwa != null && produkt.Nazwa != string.Empty && produkt.Symbol != null && produkt.Symbol != string.Empty && produkt.Magazyn != null && produkt.Magazyn != String.Empty)
            {
                mainWindow.ListaProduktow.Add(produkt);
                var query = from x in mainWindow.ListaProduktow orderby x.Magazyn, x.Nazwa select x;
                mainWindow.lstProdukty.ItemsSource = query;
                Close();
            }
        }
    }
}
