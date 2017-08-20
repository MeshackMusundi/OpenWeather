Imports Microsoft.Practices.Unity

Public Class ViewModelLocator
    Private _container As UnityContainer

    Public Sub New()
        _container = New UnityContainer
        _container.RegisterType(Of IWeatherService, OpenWeatherMapService)()
        _container.RegisterType(Of IDialogService, DialogService)()
    End Sub

    Public ReadOnly Property WeatherVM As WeatherViewModel
        Get
            Return _container.Resolve(Of WeatherViewModel)()
        End Get
    End Property
End Class
