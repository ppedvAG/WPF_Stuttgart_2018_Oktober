using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace UserControl_WebsiteChecker
{
    /// <summary>
    /// Interaction logic for UrlPreview.xaml
    /// </summary>
    public partial class UrlPreview : UserControl
    {
        public UrlPreview()
        {
            InitializeComponent();
        }

        //propdb
        public string Url
        {
            //Diesen Code niemals verändern!!!
            get { return (string)GetValue(UrlProperty); }
            set { SetValue(UrlProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Url.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UrlProperty =
            DependencyProperty.Register("Url", typeof(string), typeof(UrlPreview), new PropertyMetadata(string.Empty, new PropertyChangedCallback(UrlChanged)));

        private static void UrlChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UrlPreview preview)
            {
                preview.tbError.Visibility = Visibility.Collapsed;
                preview.frame.Visibility = Visibility.Collapsed;
            }
        }

        public event EventHandler<string> WrongURL;


        public bool Valid
        {
            get { return (bool)GetValue(ValidProperty); }
            private set { SetValue(ValidProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Valid.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValidProperty =
            DependencyProperty.Register("Valid", typeof(bool), typeof(UrlPreview), new PropertyMetadata(false));


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frame.Visibility = Visibility.Collapsed;
            HttpClient client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(8);
            try
            {
                client.GetStringAsync(Url).GetAwaiter().GetResult();
            }
            catch (Exception exp)
            {
                tbError.Text = exp.Message;
                tbError.Visibility = Visibility.Visible;
                Valid = false;
                WrongURL?.Invoke(this, Url);
                return;
            }
            Valid = true;
            tbError.Visibility = Visibility.Collapsed;
            frame.Visibility = Visibility.Visible;
            frame.Source = new Uri(Url);
        }
    }

    //class Dummy
    //{
    //    public static Dictionary<Dummy, string> StringProperty = new Dictionary<Dummy, string>();
    //    public static string Default = string.Empty;

    //    public static void AddValue(Dummy d, string value)
    //    {
    //        StringProperty.Add(d, value);
    //        ChangedCallback?.Invoke(d, value);
    //    }

    //    public Dummy()
    //    {
    //        ChangedCallback += Dummy_ChangedCallback;
    //    }

    //    private static void Dummy_ChangedCallback(Dummy arg1, string arg2)
    //    {
            
    //    }

    //    public static event Action<Dummy, string> ChangedCallback;

    //    public string Name
    //    {
    //        get
    //        {
    //            if(StringProperty.Keys.Contains(this))
    //            {
    //                return StringProperty[this];
    //            }
    //            return Default;
    //        }
    //        set
    //        {

    //        }
    //    }
    //}
}
