using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Zadanie_8._03_1
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

        public void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Zapisz_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.Filter = "WebPage|*.html";
            dialog.DefaultExt = ".html";
            dynamic doc = wbPrzegladarka.Document;
            if (doc != null)
            {
                var htmlText = doc.documentElement.InnerHtml;
                if (dialog.ShowDialog() == true && htmlText != null)
                {
                    File.WriteAllText(dialog.FileName, htmlText);
                }
            }
        }

        private void Tmp_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Opcja w budowie!");
        }

        private void RamkaOn_Click(object sender, RoutedEventArgs e)
        {
            if (brdRamka != null)
                brdRamka.BorderThickness = new Thickness(3);
        }

        private void RamkaOff_Click(object sender, RoutedEventArgs e)
        {
            if (brdRamka != null)
                brdRamka.BorderThickness = new Thickness(0);
        }

        private void OProgramie_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Prosta przeglądarka www, Wersja 1.0, Krystian 2022");
        }

        private void btnDalej_Click(object sender, RoutedEventArgs e)
        {
            if (wbPrzegladarka.CanGoForward)
                wbPrzegladarka.GoForward();
        }

        private void btnWstecz_Click(object sender, RoutedEventArgs e)
        {
            if (wbPrzegladarka.CanGoBack)
                wbPrzegladarka.GoBack();
        }

        private void txtAdres_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                try
                {
                    wbPrzegladarka.Navigate(txtAdres.Text);
                }
                catch
                {
                }
        }

        private void btnWejdz_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                wbPrzegladarka.Navigate(txtAdres.Text);
            }
            catch { }
        }

        private void wbPrzegladarka_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            txtAdres.Text = e.Uri.OriginalString;
        }

        private void wbPrzegladarka_Navigated(object sender, NavigationEventArgs e)
        {
            HideScriptErrors(wbPrzegladarka, true);
        }

        public void HideScriptErrors(WebBrowser wb, bool Hide)
        {
            dynamic activeX = this.wbPrzegladarka.GetType().InvokeMember("ActiveXInstance", BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, this.wbPrzegladarka, new object[] { });
            activeX.Silent = true;
        }
    }
}