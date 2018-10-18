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

namespace HelloWorld
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

        private void HelloButtonClick(object sender, RoutedEventArgs e)
        {
            
            MessageBox.Show("Hello World!");
            Button neuerButton = new Button()
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Right,
                Content = "Neuer Button",
                Margin = new Thickness(0, 0, 10, 0)
            };
            neuerButton.Click += NeuerButton_Click;

            this.Background = new SolidColorBrush(Colors.Red);


            this.Background = Brushes.Azure;


            if (this.Content is Grid grid)
            {
                foreach (var item in grid.Children)
                {
                    if(item is Button b1)
                    {
                        b1.Foreground = Brushes.Blue;
                    }
                }
            }
            
            mainGrid.Children.Add(neuerButton);
        }

        private void NeuerButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello World!");
            LinearGradientBrush brush = new LinearGradientBrush();
            brush.StartPoint = new Point(0, 0);
            brush.EndPoint = new Point(0, 1);
            brush.GradientStops.Add(new GradientStop(Colors.Black, 0.3));
            brush.GradientStops.Add(new GradientStop(Colors.Red, 0.6));
            brush.GradientStops.Add(new GradientStop(Colors.Gold, 0.9));
            this.Background = brush;
        }
    }
}
