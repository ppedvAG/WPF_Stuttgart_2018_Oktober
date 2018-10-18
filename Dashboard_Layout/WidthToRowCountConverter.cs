using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Dashboard_Layout
{
    public class WidthToRowCountConverter : IValueConverter, IMultiValueConverter
    {
        //Source -> Target
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(double.TryParse(value.ToString(), out double width))
            {
                double rows = 4;
                if (width > 300)
                    rows = 3;
                if (width > 600)
                    rows = 2;
                return rows;
            }

            if(value is Size size)
            {
                return (size.Width > size.Height) ? 2 : 4;
            }

            return 4;
        }

        //Target -> Source (nur bei TwoWay-Binding relevant)
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }


        //MultiBinding-Converter

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (double.TryParse(values[0].ToString(), out double value1))
            {
                if (double.TryParse(values[1].ToString(), out double value2)) {
                    switch (parameter)
                    {
                        case string wasIstErsterWert when wasIstErsterWert == "Height":
                            return (value1 > value2) ? 4 : 2;
                        case string wasIstErsterWert when wasIstErsterWert == "Width":
                            return (value1 > value2) ? 2 : 4;
                        default:
                            return (value1 > value2) ? 2 : 4;
                    }
                }
            }
            return 2;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
