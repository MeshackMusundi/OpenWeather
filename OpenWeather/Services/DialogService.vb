Public Class DialogService
    Implements IDialogService

    Public Sub ShowNotification(message As String, Optional caption As String = "") Implements IDialogService.ShowNotification
        MessageBox.Show(message, caption)
    End Sub

    Public Function ShowConfirmationRequest(message As String, Optional caption As String = "") As Boolean Implements IDialogService.ShowConfirmationRequest
        Dim result = MessageBox.Show(message, caption, MessageBoxButton.OKCancel)
        Return result.HasFlag(MessageBoxResult.OK)
    End Function
End Class
