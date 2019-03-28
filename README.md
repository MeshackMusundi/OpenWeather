# OpenWeather
![OpenWeather screenshot](https://www.codeproject.com/KB/WPF/630248/Screenshot_Budapest.png)

OpenWeather is a WPF-MVVM weather forecast application that displays three day (current day + two days) forecast for a particular location.

You can read more about the project code [here](https://www.codeproject.com/Articles/630248/WPF-OpenWeather).

## Requirements
- OpenWeatherMap [App ID](http://openweathermap.org/appid) (You will require an app ID that works with the 16 day API),
- Visual Studio 2015/17,

Once you get your App ID insert it as the value of the `APP_ID` constant in the `OpenWeatherMapService` class.
```csharp
private const string APP_ID = "PLACE-YOUR-APP-ID-HERE";
```

```vb.net
Private Const APP_ID As String = "PLACE-YOUR-APP-ID-HERE"
```

## Acknowledgements
- [OpenWeatherMap](http://openweathermap.org),
- [VClouds Weather Icons](https://vclouds.deviantart.com/art/VClouds-Weather-Icons-179152045),
- [MahApps.Metro](https://github.com/MahApps/MahApps.Metro)

