Public Interface IWeatherService
    Function GetForecastAsync(ByVal location As String, ByVal days As Integer) As Task(Of IEnumerable(Of WeatherForecast))
End Interface
