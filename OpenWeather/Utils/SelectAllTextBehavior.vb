Imports System.Windows.Interactivity

Public Class SelectAllTextBehavior
    Inherits Behavior(Of TextBox)

    Protected Overrides Sub OnAttached()
        MyBase.OnAttached()
        AddHandler AssociatedObject.PreviewKeyUp, AddressOf AssociatedObject_PreviewKeyUp
    End Sub

    Protected Overrides Sub OnDetaching()
        MyBase.OnDetaching()
        RemoveHandler AssociatedObject.PreviewKeyUp, AddressOf AssociatedObject_PreviewKeyUp
    End Sub

    Private Sub AssociatedObject_PreviewKeyUp(ByVal sender As Object, ByVal e As KeyEventArgs)
        If (e.Key = Key.Enter) Then
            AssociatedObject.SelectAll()
        End If
    End Sub
End Class