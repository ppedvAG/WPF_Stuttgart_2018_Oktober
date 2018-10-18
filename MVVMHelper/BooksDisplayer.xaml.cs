using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

namespace MVVMHelper
{
    /// <summary>
    /// Interaction logic for BooksDisplayer.xaml
    /// </summary>
    public partial class BooksDisplayer : UserControl
    {

        public ObservableCollection<Book> Books
        {
            get { return (ObservableCollection<Book>)GetValue(BooksProperty); }
            set { SetValue(BooksProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Books.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BooksProperty =
            DependencyProperty.Register(nameof(Books), typeof(ObservableCollection<Book>), typeof(BooksDisplayer), new PropertyMetadata(null));

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(BooksDisplayer), new PropertyMetadata(null));





        public DataTemplate RowDetailTemplate
        {
            get { return (DataTemplate)GetValue(RowDetailTemplateProperty); }
            set { SetValue(RowDetailTemplateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RowDetailTemplate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RowDetailTemplateProperty =
            DependencyProperty.Register("RowDetailTemplate", typeof(DataTemplate), typeof(BooksDisplayer), new PropertyMetadata(null));




        public Style ButtonStyle
        {
            get { return (Style)GetValue(ButtonStyleProperty); }
            set { SetValue(ButtonStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ButtonStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonStyleProperty =
            DependencyProperty.Register("ButtonStyle", typeof(Style), typeof(BooksDisplayer), new PropertyMetadata(null));


        public BooksDisplayer()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Book favoriteBook = (Book)datagrid.SelectedItem;
            Command?.Execute(favoriteBook);
        }

        public void Navigate_Click(object sender, RoutedEventArgs args)
        {
            if (args.OriginalSource is Hyperlink link)
            {
                Process.Start(link.NavigateUri.AbsoluteUri);
            }
        }
    }
}
