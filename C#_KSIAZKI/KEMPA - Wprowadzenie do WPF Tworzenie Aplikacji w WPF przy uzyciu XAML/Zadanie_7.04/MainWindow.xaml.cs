using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Xml.Linq;

namespace Zadanie_7._04
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string plik1 = @"..\..\..\dane\Produkty.xml";
        private string plik2 = @"..\..\..\dane\Produkty2.xml";
        private XElement wykazProduktow;

        public MainWindow()
        {
            InitializeComponent();
            PrzygotujWiazanie();
        }

        public void PrzygotujWiazanie()
        {
            if (File.Exists(plik1))
                wykazProduktow = XElement.Load(plik1);

            gridProdukty.DataContext = wykazProduktow;
            ObservableCollection<string> ListaMagazynow = new ObservableCollection<string> { "Katowice 1", "Katowice 2", "Gliwice 1" };
            nazwaMagazynu.ItemsSource = ListaMagazynow;
        }

        private void btnZapisz_Click(object sender, RoutedEventArgs e)
        {
            wykazProduktow.Save(plik2);
            MessageBox.Show("Pomyślnie zapisano dane do pliku");
        }
    }
}