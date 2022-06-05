using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ClockWPF
{
    public enum Hand {Hour, Minute, Second}
    public class HandAngleConverter : IValueConverter
    {
        public Hand Hand { get; set; } = Hand.Hour;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime dt = (DateTime) value;
            double valueAngle = 0;
            switch (Hand)
            {
                case Hand.Hour:
                    valueAngle = dt.Hour;
                    if (valueAngle > 12) valueAngle -= 12;
                    valueAngle += dt.Minute / 60.0;
                    valueAngle /= 12.0;
                    break;
                case Hand.Minute:
                    valueAngle = dt.Minute;
                    valueAngle += dt.Second / 60.0;
                    valueAngle /= 60.0;
                    break;
                case Hand.Second:
                    valueAngle = dt.Second;
                    valueAngle += dt.Millisecond / 1000.0;
                    valueAngle /= 60.0;
                    break;
            }
            valueAngle *= 360;
            return valueAngle;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
