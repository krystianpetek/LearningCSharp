using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Zadanie_6._08_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Produkt> produkty;
        public MainWindow()
        {
            InitializeComponent();
            Wiazanie();
        }
        private void Wiazanie()
        {
            produkty = new List<Produkt>();
            produkty.Add(new Produkt("01-11", "ołówek", 8, "Katowice 1"));
            produkty.Add(new Produkt("PW-20", "pióro wieczne", 75, "Katowice 2"));
            produkty.Add(new Produkt("DZ-10", "długopis żelowy", 1121, "Katowice 1"));
            produkty.Add(new Produkt("DZ-12", "długopis kulkowy", 280, "Katowice 2"));

            var query = from x in produkty orderby x.Magazyn, x.Nazwa select x;
            foreach (var item in query)
            {
                listaView.Items.Add(item);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            listaView.Items.Clear();
            var query = from x in produkty where x.Nazwa.Contains(filter.Text, StringComparison.OrdinalIgnoreCase) orderby x.Magazyn, x.Nazwa select x;
            foreach (var item in query)
            {
                listaView.Items.Add(item);
            }
        }

        private void dodajBtn_Click(object sender, RoutedEventArgs e)
        {
            CLEAR();
            Symbol.Focus();
        }

        private void usunBtn_Click(object sender, RoutedEventArgs e)
        {
            produkty.Remove(listaView.SelectedItem as Produkt);
            listaView.Items.Clear();
            var query = from x in produkty orderby x.Magazyn, x.Nazwa select x;
            foreach (var item in query)
            {
                listaView.Items.Add(item);
            }
            CLEAR();
        }

        private void zatwierdzBtn_Click(object sender, RoutedEventArgs e)
        {
            var produkt = listaView.SelectedItem as Produkt;
            if (listaView.SelectedIndex > 0)
            {
                if (produkt == null)
                    if (Nazwa.Text == "" || Symbol.Text == "" || Magazyn.Text == "")
                        return;

            }
            else
            {
                produkt = new Produkt(Symbol.Text, Nazwa.Text, int.Parse(LiczbaSztuk.Text), Magazyn.Text);
            }
            var index = produkty.IndexOf(produkt);
            if (index < 0)
            {
                produkty.Add(produkt);
            }
            else
            {
                int.TryParse(LiczbaSztuk.Text, out int liczba);
                Produkt prod = new Produkt(Symbol.Text, Nazwa.Text, liczba, Magazyn.Text);
                if (prod.Nazwa != "" && prod.Symbol != "" && Magazyn.Text != "")
                {
                    produkty[index] = prod;
                }
            }
            listaView.Items.Clear();
            var query = from x in produkty orderby x.Magazyn, x.Nazwa select x;
            foreach (var item in query)
            {
                listaView.Items.Add(item);
            }
            CLEAR();
        }

        private void CLEAR()
        {
            Symbol.Text = "";
            Nazwa.Text = "";
            Magazyn.Text = "";
            LiczbaSztuk.Text = "";
            filter.Text = "";
            listaView.SelectedValue = null;
        }

        private void listaView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = listaView.SelectedItem as Produkt;
            if (item != null)
            {
                Symbol.Text = item.Symbol;
                Nazwa.Text = item.Nazwa;
                LiczbaSztuk.Text = item.LiczbaSztuk.ToString();
                Magazyn.Text = item.Magazyn;
            }
        }
    }
}