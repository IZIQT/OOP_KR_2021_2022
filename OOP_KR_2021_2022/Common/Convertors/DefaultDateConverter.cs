using System;
using System.Globalization;
using System.Windows.Data;

namespace OOP_KR_2021_2022.Common.Convertors
{
    class DefaultDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((DateTime)value == new DateTime() || (DateTime)value == null)
            {
                return "";
            }
            else
            {
                return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
