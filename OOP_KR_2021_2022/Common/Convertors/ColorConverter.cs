using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace OOP_KR_2021_2022.Common.Convertors
{
    class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //try
            //{
                if (value != null && System.Convert.IsDBNull(value)) return Brushes.Black;
                if ((DateTime)value > DateTime.Now)
                {
                    return Brushes.Black;
                }
                else
                {
                    return Brushes.Red;
                }
            //}
            //catch
            //{
            //    return Brushes.Brown;
            //}
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
