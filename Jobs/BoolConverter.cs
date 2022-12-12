using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RizkyApps.Jobs
{
    internal class BoolConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dat = value.ToString();
            if (dat.ToUpper() == "YES")
            {
                return true;
            }
            else{
                return false;
            }
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dat = (bool) value;
            if (dat)
            {
                return "YES";
            }
            else
            {
                return "NO";
            }
        }
    }
}
