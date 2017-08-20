Imports System.Globalization

Public Class TemperatureConverter
    Implements IMultiValueConverter

    Public Function Convert(values() As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IMultiValueConverter.Convert
        Dim icon = CStr(values(0))
        Dim dayTemperature = CDbl(values(1))
        Dim nightTemperature = CDbl(values(2))

        If icon Is Nothing Then Return Binding.DoNothing

        If icon.ElementAt(2) = "d" Then Return dayTemperature Else Return nightTemperature
    End Function

    Public Function ConvertBack(value As Object, targetTypes() As Type, parameter As Object, culture As CultureInfo) As Object() Implements IMultiValueConverter.ConvertBack
        Return Binding.DoNothing
    End Function
End Class
