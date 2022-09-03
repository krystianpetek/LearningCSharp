using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Zadanie_6._06
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

            //// CollectionView
            //lstProdukty.ItemsSource = ListaProduktow;
            //CollectionView widok = (CollectionView)CollectionViewSource.GetDefaultView(lstProdukty.ItemsSource);
            //widok.SortDescriptions.Add(new SortDescription("Magazyn", ListSortDirection.Ascending));
            //widok.SortDescriptions.Add(new SortDescription("Nazwa", ListSortDirection.Ascending));
            //widok.Filter = FiltrUzytkownika;

            // LINQ
            var query = from x in ListaProduktow orderby x.Magazyn, x.Nazwa select x;
            lstProdukty.ItemsSource = query;
        }

        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            //// CollectionView
            //CollectionViewSource.GetDefaultView(lstProdukty.ItemsSource).Refresh();

            // LINQ
            var query = from x in ListaProduktow where x.Nazwa.Contains(txtFilter.Text, StringComparison.OrdinalIgnoreCase) orderby x.Magazyn, x.Nazwa select x;
            lstProdukty.ItemsSource = query;
        }

        //// CollectionView
        //private bool FiltrUzytkownika(object item)
        //{
        //    if (string.IsNullOrEmpty(txtFilter.Text))
        //        return true;
        //    else
        //        return ((item as Produkt).Nazwa.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        //}
    }
}