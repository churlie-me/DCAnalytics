using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace DCAnalyticsMobile.Utils
{
    public class SequenceColourConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var seq = (int)value;
            Color returnValue;

            returnValue = seq % 2 == 0 ? Color.FromHex("#FFFFFF") : Color.FromHex("#0178BC");

            return returnValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
