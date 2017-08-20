using OpenWeatherCS.Models;
using System;
using System.Collections.Generic;

namespace OpenWeatherCS.SampleData
{
    public class SampleWeatherViewModel
    {

        public List<WeatherForecast> Forecast { get; set; }
        public WeatherForecast CurrentWeather { get; set; }

        public SampleWeatherViewModel()
        {
            CurrentWeather = new WeatherForecast()
            {
                Date = DateTime.Now, Humidity = 82,  ID = 202, MaxTemperature = 34.12,
                MinTemperature = 20.45, Pressure = 843.16, IconID = "11d", DayTemperature = 23.55,
                NightTemperature = 18.35, Description = "thunderstorm with heavy rain ",
                WindDirection = "NE", WindSpeed = 1.85, WindType = "Light breeze"
            };

            Forecast = new List<WeatherForecast>();
            Forecast.Add(new WeatherForecast()
            {
                Date = new DateTime(2017, 8, 3), Humidity = 82, ID = 310, MaxTemperature = 18.33, MinTemperature = 12.78,
                Pressure = 843.16, IconID = "09d", DayTemperature = 23, Description = "light intensity drizzle rain",
                WindDirection = "NE", WindSpeed = 1.85, WindType = "Light breeze"
            });
            Forecast.Add(new WeatherForecast()
            {
                Date = new DateTime(2017, 8, 4), Humidity = 82, ID = 800, MaxTemperature = 34.65, MinTemperature = 20.32,
                Pressure = 843.16, IconID = "10d", DayTemperature = 23, Description = "clear day",
                WindDirection = "NE", WindSpeed = 1.85, WindType = "Light breeze"
            });
        }
    }
}
