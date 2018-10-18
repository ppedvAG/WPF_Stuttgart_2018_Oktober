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

namespace Dashboard_Layout
{
    /// <summary>
    /// Interaction logic for Chart.xaml
    /// </summary>
    public partial class Chart : UserControl
    {

        public Style TextBlockStyle
        {
            get
            {
                foreach (var item in stack1.Children)
                {
                    if (item is TextBlock block)
                    {
                        return block.Style;
                    }
                }
                throw new Exception();
            }
            set
            {
                foreach (var item in stack1.Children)
                {
                    if (item is TextBlock block)
                    {
                        block.Style = value;
                    }
                }
            }
        }




        //private DataTemplate _textBlockTemplate;

        //public DataTemplate TextBlockTemplate
        //{
        //    get { return _textBlockTemplate; }
        //    set
        //    {
        //        _textBlockTemplate = value;
        //        presenter.ContentTemplate = value;
        //    }
        //}


        //public Brush Schriftfarbe
        //{

        //    get
        //    {
        //        foreach (var item in stack1.Children)
        //        {
        //            if (item is TextBlock block)
        //            {
        //                return block.Foreground;
        //            }
        //        }
        //        throw new Exception();
        //    }
        //    set
        //    {
        //        foreach (var item in stack1.Children)
        //        {
        //            if (item is TextBlock block)
        //            {
        //                block.Foreground = value;
        //            }
        //        }
        //    }
        //}

        public Chart()
        {
            InitializeComponent();
        }
    }
}
