using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Zadanie_7._05_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Produkt> ListaProduktow;

        public MainWindow()
        {
            InitializeComponent();
            PrzygotujWiazanie();
        }

        public void PrzygotujWiazanie()
        {
            ListaProduktow = new ObservableCollection<Produkt>();

            ListaProduktow.Add(new Produkt("01-11", "ołówek", 8, "Katowice 1", new Uri("../../../img/olowek.jpg", UriKind.Relative), "Ołówek z gumką HB"));
            ListaProduktow.Add(new Produkt("PW-20", "pióro wieczne", 75, "Katowice 2", new Uri(@"..\..\..\img\pioro.jpg", UriKind.Relative), "opis ołówka w kato"));
            ListaProduktow.Add(new Produkt("DZ-10", "długopis żelowy", 1121, "Katowice 1", new Uri(@"..\..\..\img\zelowy.jpg", UriKind.Relative), "opis ołówka w kato"));
            ListaProduktow.Add(new Produkt("DZ-12", "długopis kulowy", 280, "Katowice 2", new Uri(@"..\..\..\img\kulkowy.jpg", UriKind.Relative), "opis ołówka w kato"));

            gridProdukty.ItemsSource = ListaProduktow;

            ObservableCollection<string> lista = new ObservableCollection<string>() { "Katowice 1", "Katowice 2", "Gliwice 1" };
            nazwaMagazynu.ItemsSource = lista;

            var widok = CollectionViewSource.GetDefaultView(gridProdukty.ItemsSource);
            widok.GroupDescriptions.Add(new PropertyGroupDescription("Magazyn"));
        }

        private void btnZdjecie_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Title = "Wybierz zdjęcie";
            openFileDialog.Filter = "Image files (*.jpg,*.png;*.jpeg)|*.jpg;*.png;*.jpeg|Allfiles (*.*)|*.*";
            openFileDialog.InitialDirectory = @"C:\temp\";
            if (openFileDialog.ShowDialog() == true)
            {
                (gridProdukty.SelectedItem as Produkt).Zdjecie = new Uri(openFileDialog.FileName);
                gridProdukty.CommitEdit(DataGridEditingUnit.Cell, true);
                gridProdukty.CommitEdit();
                CollectionViewSource.GetDefaultView(gridProdukty.ItemsSource).Refresh();
            }
        }
    }
}