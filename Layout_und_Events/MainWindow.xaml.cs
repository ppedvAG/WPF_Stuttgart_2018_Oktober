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

namespace Layout_und_Events
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string chosenColor = string.Empty;

        public MainWindow()
        {
            InitializeComponent();
            //Attached Properties per Code setzen und lesen
            DockPanel.SetDock(dockpanelHeader, Dock.Top);
            DockPanel.GetDock(dockpanelHeader);
            Geschlechter asd = Geschlechter.Männlich;


            //Event wird auf jeden Fall behandelt
            //this.AddHandler(Button.ClickEvent, new RoutedEventHandler((a,sdd) => MessageBox.Show("Click")),true);
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            //OriginalSource verweist auf das Control, was ursprünglich das Event ausgelöst hat
            if(e.OriginalSource is RadioButton radio)
            {
                chosenColor = radio.Content.ToString();
            }    
        }

        int globalClicks = 0;

        private void Window_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            //Programm schrotten
            //das Event wird e.Handled als behandelt gesetzt und kein anderes Control kann das dieses Event
            //mehr erneut behandeln, es sei denn es hat seinen EventHandler mit AddHanlder(Event,Handler, true); registriert.
            //e.Handled = true;
            globalClicks++;
            this.Title = $"Clicks: {globalClicks}";
        }

        private void Button_Abschicken_Click(object sender, RoutedEventArgs e)
        {
            string name = tbName.Text;
            int alter = (int)sliderAlter.Value;
            Geschlechter geschlecht = (Geschlechter)cbGeschlecht.SelectedItem;
            MessageBox.Show($"{name}({alter} Jahre alt),{geschlecht} mag die Farbe {chosenColor}");

        }
    }

    public enum Geschlechter
    {
        Männlich, Weiblich, Sonstiges
    }
}
