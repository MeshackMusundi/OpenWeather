using System.Collections.Generic;
using OpenWeatherCS.Models;
using System.Threading.Tasks;

namespace OpenWeatherCS.Services
{
    public interface IWeatherService
    {
        Task<IEnumerable<WeatherForecast>> GetForecastAsync(string location, int days);
    }
}
