using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace OpenWeatherCS.Converters
{
    public class WeatherIconConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var id = (int) values[0];
            var iconID = (string) values[1];

            if (iconID == null) return Binding.DoNothing;

            var timePeriod = iconID.ToCharArray()[2]; // This is either d or n (day or night)
            var pack = "pack://application:,,,/OpenWeather;component/WeatherIcons/";
            var img = string.Empty;

            if (id >= 200 && id < 300) img = "thunderstorm.png";
            else if (id >= 300 && id < 500) img = "drizzle.png";
            else if (id >= 500 && id < 600) img = "rain.png";
            else if (id >= 600 && id < 700) img = "snow.png";
            else if (id >= 700 && id < 800) img = "atmosphere.png";
            else if (id == 800) img = (timePeriod == 'd') ? "clear_day.png" : "clear_night.png";
            else if (id == 801) img = (timePeriod == 'd') ? "few_clouds_day.png" : "few_clouds_night.png";
            else if (id == 802 || id == 803) img = (timePeriod == 'd') ? "broken_clouds_day.png" : "broken_clouds_night.png";
            else if (id == 804) img = "overcast_clouds.png";
            else if (id >= 900 && id < 903) img = "extreme.png";
            else if (id == 903) img = "cold.png";
            else if (id == 904) img = "hot.png";
            else if (id == 905 || id >= 951) img = "windy.png";
            else if (id == 906) img = "hail.png";

            Uri source = new Uri(pack + img);

            BitmapImage bmp = new BitmapImage();
            bmp.BeginInit();
            bmp.UriSource = source;
            bmp.EndInit();

            return bmp;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return (object[]) Binding.DoNothing;
        }
    }
}