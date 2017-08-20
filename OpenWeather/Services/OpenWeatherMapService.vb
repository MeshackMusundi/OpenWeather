Imports System.Net.Http
Imports System.IO
Imports System.Net

Public Class OpenWeatherMapService
    Implements IWeatherService

    Private Const APP_ID As String = "PLACE-YOUR-APP-ID-HERE"
    Private Const MAX_FORECAST_DAYS As Integer = 5
    Private client As HttpClient


    Public Sub New()
        client = New HttpClient
        client.BaseAddress = New Uri("http://api.openweathermap.org/data/2.5/")
    End Sub

    Public Async Function GetForecastAsync(location As String, days As Integer) As Task(Of IEnumerable(Of WeatherForecast)) Implements IWeatherService.GetForecastAsync
        If location Is Nothing Then Throw New ArgumentNullException("Location can't be null.")
        If location = String.Empty Then Throw New ArgumentException("Location can't be an empty string.")
        If days <= 0 Then Throw New ArgumentOutOfRangeException("Days should be greater than zero.")
        If days > MAX_FORECAST_DAYS Then Throw New ArgumentOutOfRangeException($"Days can't be greater than {MAX_FORECAST_DAYS}.")

        Dim query = $"forecast/daily?q={location}&type=accurate&mode=xml&units=metric&cnt={days}&appid={APP_ID}"
        Dim response = Await client.GetAsync(query)

        Select Case response.StatusCode
            Case HttpStatusCode.Unauthorized
                Throw New UnauthorizedApiAccessException("Invalid API key.")
            Case HttpStatusCode.NotFound
                Throw New LocationNotFoundException("Location not found.")
            Case HttpStatusCode.OK
                Dim s = Await response.Content.ReadAsStringAsync()
                Dim x = XElement.Load(New StringReader(s))
                Dim data = x...<time>.Select(Function(w) New WeatherForecast With {
                                                 .Description = w.<symbol>.@name,
                                                 .ID = w.<symbol>.@number,
                                                 .IconID = w.<symbol>.@var,
                                                 .[Date] = w.@day,
                                                 .WindType = w.<windSpeed>.@name,
                                                 .WindSpeed = w.<windSpeed>.@mps,
                                                 .WindDirection = w.<windDirection>.@code,
                                                 .DayTemperature = w.<temperature>.@day,
                                                 .NightTemperature = w.<temperature>.@night,
                                                 .MaxTemperature = w.<temperature>.@max,
                                                 .MinTemperature = w.<temperature>.@min,
                                                 .Pressure = w.<pressure>.@value,
                                                 .Humidity = w.<humidity>.@value})
                Return data
            Case Else
                Throw New NotImplementedException(response.StatusCode.ToString())
        End Select
    End Function
End Class
