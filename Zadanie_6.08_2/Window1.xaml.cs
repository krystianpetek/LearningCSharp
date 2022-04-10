using System.Windows;

namespace Zadanie_6._08_2
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private MainWindow mainWindow = null;
        public Window1()
        {
            InitializeComponent();
        }
        public Window1(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            PrzygotujWiazanie();
        }
        private void PrzygotujWiazanie()
        {
            Produkt produktZListy = mainWindow.lstProdukty.SelectedItem as Produkt;
            if (produktZListy != null)
            {
                gridProdukt.DataContext = produktZListy;
            }
        }
        private void btnPotwierdz_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
