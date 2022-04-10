using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Zadanie_6._03
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

            // LINQ
            var query = from x in ListaProduktow orderby x.Magazyn, x.Nazwa select x;
            lstProdukty.ItemsSource = query;

            // CollectionView
            //lstProdukty.ItemsSource = ListaProduktow;
            //var widok = CollectionViewSource.GetDefaultView(lstProdukty.ItemsSource);
            //widok.SortDescriptions.Add(new SortDescription("Magazyn", ListSortDirection.Ascending));
            //widok.SortDescriptions.Add(new SortDescription("Nazwa", ListSortDirection.Ascending));
        }
    }
}