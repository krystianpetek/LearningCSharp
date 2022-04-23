﻿using System.Collections.ObjectModel;
using System.Windows;

namespace Zadanie_7._03
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

        private void PrzygotujWiazanie()
        {
            ListaProduktow = new ObservableCollection<Produkt>();

            ListaProduktow.Add(new Produkt("01-11", "ołówek", 8, "Katowice 1"));
            ListaProduktow.Add(new Produkt("PW-20", "pióro wieczne", 75, "Katowice 2"));
            ListaProduktow.Add(new Produkt("DZ-10", "długopis żelowy", 1121, "Katowice 1"));
            ListaProduktow.Add(new Produkt("DZ-12", "długopis kulowy", 280, "Katowice 2"));

            gridProdukty.ItemsSource = ListaProduktow;
            ObservableCollection<string> ListaMagazynow = new ObservableCollection<string>() { "Katowice 1", "Katowice 2", "Gliwice1" };
            nazwaMagazynu.ItemsSource = ListaMagazynow;
        }
    }
}