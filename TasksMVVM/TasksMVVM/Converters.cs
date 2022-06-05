using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using TasksMVVM.Model;

namespace TasksMVVM
{
    public class BoolToBrushConverter : IValueConverter
    {
        public Brush FalseColor { get; set; } = Brushes.Black;
        public Brush TrueColor { get; set; } = Brushes.Gray;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool b = (bool) value;
            return !b ? FalseColor : TrueColor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class TaskConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string desc = (string) values[0];
            DateTime created = DateTime.Now;
            DateTime? eta = (DateTime?) values[1];
            Priority priority = (Priority) (int) values[2];
            if (!string.IsNullOrWhiteSpace(desc) && eta.HasValue)
                return new ViewModel.STask(desc, created, eta.Value, priority, false);
            else return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
