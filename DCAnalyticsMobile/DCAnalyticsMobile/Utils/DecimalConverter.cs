using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace DCAnalyticsMobile.Utils
{
    public class DecimalConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object paramater, CultureInfo culture)
        {
            double result = 0;
            if (value != null && (double.TryParse(value.ToString(), out result)))
                return Math.Round(result, 1);
            else
                return value;
        }

        public object ConvertBack(object value, Type targetType, object paramater, CultureInfo culture)
        {
            return value;
        }
    }
}
