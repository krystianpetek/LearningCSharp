using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace AppMVVM_WFAiIS.ViewModel
{
    internal class DoubleToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double valueOfBrush = (double)value;
            double red = valueOfBrush > 127 ? 255 : 2 * valueOfBrush;
            double green = valueOfBrush < 127 ? 255 : 255 - 2 * (valueOfBrush - 128);
            Color color = Color.FromRgb((byte)red, (byte)green, 0);
            return new SolidColorBrush(color);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
