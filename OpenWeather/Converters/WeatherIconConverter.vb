Imports System.Globalization

Public Class WeatherIconConverter
    Implements IMultiValueConverter

    Public Function Convert(values() As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IMultiValueConverter.Convert
        Dim id = CInt(values(0))
        Dim iconID = CStr(values(1))

        If iconID Is Nothing Then Return Binding.DoNothing

        Dim timePeriod = iconID.ElementAt(2) ' This is either d or n (day or night)
        Dim pack = "pack://application:,,,/OpenWeather;component/WeatherIcons/"
        Dim img = String.Empty

        If id >= 200 AndAlso id < 300 Then
            img = "thunderstorm.png"
        ElseIf id >= 300 AndAlso id < 500 Then
            img = "drizzle.png"
        ElseIf id >= 500 AndAlso id < 600 Then
            img = "rain.png"
        ElseIf id >= 600 AndAlso id < 700 Then
            img = "snow.png"
        ElseIf id >= 700 AndAlso id < 800 Then
            img = "atmosphere.png"
        ElseIf id = 800 Then
            If timePeriod = "d" Then img = "clear_day.png" Else img = "clear_night.png"
        ElseIf id = 801 Then
            If timePeriod = "d" Then img = "few_clouds_day.png" Else img = "few_clouds_night.png"
        ElseIf id = 802 Or id = 803 Then
            If timePeriod = "d" Then img = "broken_clouds_day.png" Else img = "broken_clouds_night.png"
        ElseIf id = 804 Then
            img = "overcast_clouds.png"
        ElseIf id >= 900 AndAlso id < 903 Then
            img = "extreme.png"
        ElseIf id = 903 Then
            img = "cold.png"
        ElseIf id = 904 Then
            img = "hot.png"
        ElseIf id = 905 Or id >= 951 Then
            img = "windy.png"
        ElseIf id = 906 Then
            img = "hail.png"
        End If

        Dim source As New Uri(pack & img)

        Dim bmp As New BitmapImage
        bmp.BeginInit()
        bmp.UriSource = source
        bmp.EndInit()

        Return bmp
    End Function

    Public Function ConvertBack(value As Object, targetTypes() As Type, parameter As Object, culture As CultureInfo) As Object() Implements IMultiValueConverter.ConvertBack
        Return Binding.DoNothing
    End Function
End Class
