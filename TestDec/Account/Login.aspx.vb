
Partial Class Account_Login
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        RegisterHyperLink.NavigateUrl = "Register"

        Dim returnUrl = HttpUtility.UrlEncode(Request.QueryString("ReturnUrl"))
        If Not String.IsNullOrEmpty(returnUrl) Then
            RegisterHyperLink.NavigateUrl &= "?ReturnUrl=" & returnUrl
        End If
    End Sub

    ''' <summary>
    ''' Jus a dummy function.
    ''' </summary>
    ''' <param name="resourceKey"></param>
    ''' <returns></returns>
    Public Function GetMaskedLocalResource(resourceKey As String) As String
        Return ""
    End Function

    ''' <summary>
    ''' Jus a dummy function.
    ''' </summary>
    ''' <param name="resourceKey"></param>
    ''' <returns></returns>
    Public Function GetMaskedGlobalResource(resourceKey As String) As String
        Return ""
    End Function
End Class