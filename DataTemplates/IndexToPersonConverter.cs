using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DataTemplates
{
    public class IndexToPersonConverter : IValueConverter,IMultiValueConverter
    {



        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if(int.TryParse(values[0].ToString(),  out int index))
            {
                if(values[1] is IList list)
                {
                    try
                    {
                        object p = list[index - 1];
                        return p.ToString();
                    }
                    catch (Exception)
                    {
                        return null; 
                    }
                }
            }
            return null;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
