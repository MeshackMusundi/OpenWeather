using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace OpenWeatherCS.Converters
{
    public class TemperatureConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var icon = (string) values[0];
            var dayTemperature = (double) values[1];
            var nightTemperature = (double) values[2];

            if (icon == null) return Binding.DoNothing;

            return (icon.ElementAt(2) == 'd') ? dayTemperature : nightTemperature;            
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return (object[]) Binding.DoNothing;
        }
    }
}
