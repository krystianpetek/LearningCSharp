﻿using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Data;

namespace AppMVVM_3_WFAiIS.ViewModel
{
    internal class BoolToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool b = (bool)value;
            Brush x = (b) ? Brushes.Black : Brushes.Red;
            return x;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}