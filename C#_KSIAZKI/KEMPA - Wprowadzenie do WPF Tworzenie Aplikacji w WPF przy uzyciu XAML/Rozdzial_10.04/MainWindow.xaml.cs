using System.Collections.ObjectModel;
using System.Windows;

namespace Rozdzial_10._04
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Produkt> listaProduktow;

        public MainWindow()
        {
            InitializeComponent();
            PrzygotujWiazanie();
        }

        private void PrzygotujWiazanie()
        {
            listaProduktow = new ObservableCollection<Produkt>();

            listaProduktow.Add(new Produkt("01-11", "ołówek", 8, "Katowice 1"));
            listaProduktow.Add(new Produkt("PW-20", "pióro wieczne", 75, "Katowice 2"));
            listaProduktow.Add(new Produkt("DZ-10", "długopis żelowy", 1121, "Katowice 1"));
            listaProduktow.Add(new Produkt("DZ-12", "długopis kulowy", 280, "Katowice 2"));

            gridProdukty.ItemsSource = listaProduktow;
        }
    }
}
