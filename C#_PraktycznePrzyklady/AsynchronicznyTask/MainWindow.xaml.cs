using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.IO;

namespace AsynchronicznyTask
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Directory.SetCurrentDirectory("../../../");
        }

        private void Read_Files_Handler(object sender, RoutedEventArgs e)
        {
            ResultLab.Content = "Reading started:";
            var stopwatch = Stopwatch.StartNew();
            ProcessFiles();
            stopwatch.Stop();
            ResultLab.Content = $"Finished in: {stopwatch.ElapsedMilliseconds} ms";
        }

        private void ProcessFiles()
        {
            var filePath = Directory.GetCurrentDirectory()+System.IO.Path.DirectorySeparatorChar+"txt";
            for (int i = 1; i <= 5; i++)
            {
                var file = File.Open($"{filePath}/{i}.txt", FileMode.Open);

                using (var reader = new StreamReader(file, Encoding.UTF8))
                {
                    ResultLab.Content = $"Reading {filePath}/{i}.txt";
                    var fileContent = reader.ReadToEnd();
                    
                        ResultLab.Content = $"Przetwarzanie pliku {i}.txt";
                        string laczenie = String.Empty;
                        foreach (var x in fileContent)
                        {
                            laczenie += x;
                        }
                }
            }
        }

        private async void Read_Files_Async_Handler(object sender, RoutedEventArgs e)
        {
            ResultLabAsync.Content = "Reading started:";
            var stopwatch = Stopwatch.StartNew();
            await ProcessFilesAsync();
            stopwatch.Stop();
            ResultLabAsync.Content = $"Finished in: {stopwatch.ElapsedMilliseconds} ms";
        }
        private async Task ProcessFilesAsync()
        {
            var filePath = Directory.GetCurrentDirectory() + System.IO.Path.DirectorySeparatorChar + "txt";
            for (int i = 1; i <= 5; i++)
            {
                var file = File.Open($"{filePath}/{i}.txt", FileMode.Open);

                using (var reader = new StreamReader(file, Encoding.UTF8))
                {
                    ResultLabAsync.Content = $"Reading {filePath}/{i}.txt";
                    var fileContent = await Task.Run(() => reader.ReadToEnd());
                    for (int j = 1; j <= 10; j++)
                    {
                        ResultLabAsync.Content = $"Przetwarzanie {j} pliku {i}.txt";
                        string laczenie = String.Empty;
                        foreach (var x in fileContent)
                        {
                            await Task.Run(() => laczenie += x);
                        }
                    }
                }
            }
        }
    }
}
