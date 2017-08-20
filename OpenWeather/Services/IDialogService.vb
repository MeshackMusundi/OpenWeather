Public Interface IDialogService
    Sub ShowNotification(message As String, Optional caption As String = "")
    Function ShowConfirmationRequest(message As String, Optional caption As String = "") As Boolean
End Interface
