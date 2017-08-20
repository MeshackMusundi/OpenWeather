Imports System.Net.Http

Public Class WeatherViewModel
    Inherits ViewModelBase

    Private weatherService As IWeatherService
    Private dialogService As IDialogService

    Public Sub New(ByVal ws As IWeatherService, ByVal ds As IDialogService)
        weatherService = ws
        dialogService = ds
    End Sub

    Private _forecast As List(Of WeatherForecast)
    Public Property Forecast As List(Of WeatherForecast)
        Get
            Return _forecast
        End Get
        Set(value As List(Of WeatherForecast))
            _forecast = value
            OnPropertyChanged()
        End Set
    End Property

    Private _currentWeather As New WeatherForecast
    Public Property CurrentWeather As WeatherForecast
        Get
            Return _currentWeather
        End Get
        Set(value As WeatherForecast)
            _currentWeather = value
            OnPropertyChanged()
        End Set
    End Property

    Private _location As String
    Public Property Location As String
        Get
            Return _location
        End Get
        Set(value As String)
            _location = value
            OnPropertyChanged()
        End Set
    End Property

    Private Property _getWeatherCommand As ICommand
    Public ReadOnly Property GetWeatherCommand As ICommand
        Get
            If _getWeatherCommand Is Nothing Then _getWeatherCommand =
                New RelayCommandAsync(Function() GetWeather(), Function() CanGetWeather())
            Return _getWeatherCommand
        End Get
    End Property

    Public Async Function GetWeather() As Task
        Try
            Dim weather = Await weatherService.GetForecastAsync(Location, 3)
            CurrentWeather = weather.First
            Forecast = weather.Skip(1).Take(2).ToList
        Catch ex As HttpRequestException
            dialogService.ShowNotification("Ensure you're connected to the internet!", "Open Weather")
        Catch ex As LocationNotFoundException
            dialogService.ShowNotification("Location not found!", "Open Weather")
        End Try
    End Function

    Public Function CanGetWeather() As Boolean
        Return Location IsNot String.Empty
    End Function
End Class