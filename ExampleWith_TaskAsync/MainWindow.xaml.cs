using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

namespace ExampleWith_TaskAsync
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonSync_Click(object sender, RoutedEventArgs e)
        {
            StatusSync.Content = "Start...";
            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 1; i < 3; i++)
            {
                var pathToFile = FindFile(i);

                for (int j = 0; j < 50; j++)
                {
                    using (var reader = new StreamReader(pathToFile, Encoding.UTF8))
                    {
                        var readContent = reader.ReadToEnd();
                    }
                }
            }
            stopwatch.Stop();
            StatusSync.Content = $"Elapsed {stopwatch.ElapsedMilliseconds} ms";

        }

        private async void ButtonAsync_Click(object sender, RoutedEventArgs e)
        {
            await ButtonAsyncMethod();
        }

        private async void ButtonAsyncLinear_Click(object sender, RoutedEventArgs e)
        {
            await ButtonAsync2Method();

        }

        private string FindFile(int id)
        {
            string path = Directory.GetCurrentDirectory();
            path = System.IO.Path.Combine(path, $"..\\..\\file{id}.txt");
            return path;
        }

        private async Task ButtonAsyncMethod()
        {
            StatusAsync.Content = "Start...";
            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 1; i < 3; i++)
            {
                await Task.Run(() =>
                {
                    var pathToFile = FindFile(i);

                    for (int j = 0; j < 50; j++)
                    {
                        using (var reader = new StreamReader(pathToFile, Encoding.UTF8))
                        {
                            var readContent = reader.ReadToEnd();
                        }
                    }
                });
            }
            stopwatch.Stop();
            StatusAsync.Content = $"Elapsed {stopwatch.ElapsedMilliseconds} ms";
        }

        private async Task ButtonAsync2Method()
        {
            StatusAsyncLinear.Content = "Start...";
            Stopwatch stopwatch = Stopwatch.StartNew();

            List<Task> tasks = new List<Task>();


            for (int i = 1; i < 3; i++)
            {
                tasks.Add(Task.Run(() =>
                {
                    var pathToFile = FindFile(i);

                    for (int j = 0; j < 50; j++)
                    {
                        using (var reader = new StreamReader(pathToFile, Encoding.UTF8))
                        {
                            var readContent = reader.ReadToEnd();
                        }
                    }
                }));
            }
            await Task.WhenAll(tasks);
            stopwatch.Stop();
            StatusAsyncLinear.Content = $"Elapsed {stopwatch.ElapsedMilliseconds} ms";
        }
    }
}
