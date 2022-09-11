﻿using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Zadanie_7._05_1
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

            ListaProduktow.Add(new Produkt("01-11", "ołówek", 8, "Katowice 1", new Uri("../../../img/olowek.jpg", UriKind.Relative)));
            ListaProduktow.Add(new Produkt("PW-20", "pióro wieczne", 75, "Katowice 2", new Uri(@"..\..\..\img\pioro.jpg", UriKind.Relative)));
            ListaProduktow.Add(new Produkt("DZ-10", "długopis żelowy", 1121, "Katowice 1", new Uri(@"..\..\..\img\zelowy.jpg", UriKind.Relative)));
            ListaProduktow.Add(new Produkt("DZ-12", "długopis kulowy", 280, "Katowice 2", new Uri(@"..\..\..\img\kulkowy.jpg", UriKind.Relative)));

            gridProdukty.ItemsSource = ListaProduktow;

            ObservableCollection<string> lista = new ObservableCollection<string>() { "Katowice 1", "Katowice 2", "Gliwice 1" };
            nazwaMagazynu.ItemsSource = lista;
        }
    }
}