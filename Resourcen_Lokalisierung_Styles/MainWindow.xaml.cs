using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Resourcen_Lokalisierung_Styles
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            System.Double fontSize = 4;
            //this.Title = Properties.Resources.HelloWorld;
        }

        private void Button_Bestellen_Click(object sender, RoutedEventArgs e)
        {
            this.Resources["windowFontSize"] = 60.0;
            //MessageBox.Show(this.Resources["windowFontSize"].ToString());
        }

        private void Sprache_Wechseln_Click(object sender, RoutedEventArgs e)
        {
            if(e.OriginalSource is MenuItem item)
            {
                //https://docs.microsoft.com/de-de/dotnet/framework/wpf/app-development/pack-uris-in-wpf
                Application.Current.Resources.MergedDictionaries[0].Source = new Uri($"pack://application:,,,/Sprachen/{item.Tag}");
                new MainWindow().Show();
                this.Close();

                //Sprache wechseln mit ResX-Dateien
                //Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("de");
                //Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("de");
            }
        }

        private void Style_Wechseln_Click(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is MenuItem item)
            {
                //https://docs.microsoft.com/de-de/dotnet/framework/wpf/app-development/pack-uris-in-wpf
                Application.Current.Resources.MergedDictionaries[2].Source = new Uri($"pack://siteOfOrigin:,,,/Styles/{item.Tag}");
            }
        }
    }
}
