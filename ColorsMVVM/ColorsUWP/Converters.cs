using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace ColorsUWP
{
    public class ByteToDoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (double)(byte) value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return (byte)(double) value;
        }
    }

    public class ColorToSolidColorBrushConverter : IValueConverter
    {
        private SolidColorBrush brush = new SolidColorBrush();
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Color kolor = (Color) value;
            brush.Color = kolor;
            return brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class DoubleToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return ((double) value).ToString("N0");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class SDColorToSMColorConverter : IValueConverter
    {
        private Color kolor = new Color();
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            kolor.A = ((System.Drawing.Color) value).A;
            kolor.R = ((System.Drawing.Color) value).R;
            kolor.G = ((System.Drawing.Color) value).G;
            kolor.B = ((System.Drawing.Color) value).B;
            return kolor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    //public class DoubleToBrushConverter : IMultiValueConverter
    //{
    //    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        byte r = (byte)(double) values[0];
    //        byte g = (byte)(double) values[1];
    //        byte b = (byte)(double) values[2];
    //        return new SolidColorBrush(Color.FromRgb(r, g, b));
    //    }

    //    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    //public class RGBToBrushConverter : IMultiValueConverter
    //{
    //    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        byte r = (byte) values[0];
    //        byte g = (byte) values[1];
    //        byte b = (byte) values[2];
    //        return new SolidColorBrush(Color.FromRgb(r, g, b));
    //    }

    //    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    //    {
    //        SolidColorBrush brush = value as SolidColorBrush;
    //        if (brush != null)
    //        {
    //            Color kolor = brush.Color;
    //            return new object[3] {kolor.R, kolor.G, kolor.B};
    //        }
    //        else return new object[3] {0, 0, 0};
    //    }
    //}
}
