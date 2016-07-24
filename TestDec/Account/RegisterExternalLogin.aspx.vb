Imports System.Web.Security
Imports DotNetOpenAuth.AspNet
Imports Microsoft.AspNet.Membership.OpenAuth

Partial Class Account_RegisterExternalLogin
    Inherits System.Web.UI.Page

    Protected Property ProviderName As String
        Get
            Return If(DirectCast(ViewState("ProviderName"), String), String.Empty)
        End Get
        Private Set(value As String)
            ViewState("ProviderName") = value
        End Set
    End Property

    Protected Property ProviderDisplayName As String
        Get
            Return If(DirectCast(ViewState("PropertyProviderDisplayName"), String), String.Empty)
        End Get
        Private Set(value As String)
            ViewState("ProviderDisplayName") = value
        End Set
    End Property

    Protected Property ProviderUserId As String
        Get
            Return If(DirectCast(ViewState("ProviderUserId"), String), String.Empty)
        End Get

        Private Set(value As String)
            ViewState("ProviderUserId") = value
        End Set
    End Property

    Protected Property ProviderUserName As String
        Get
            Return If(DirectCast(ViewState("ProviderUserName"), String), String.Empty)
        End Get

        Private Set(value As String)
            ViewState("ProviderUserName") = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ProcessProviderResult()
        End If
    End Sub

    Protected Sub logIn_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        CreateAndLoginUser()
    End Sub

    Protected Sub cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        RedirectToReturnUrl()
    End Sub

    Private Sub ProcessProviderResult()
        
    End Sub

    Private Sub CreateAndLoginUser()
        If Not IsValid Then
            Return
        End If
    End Sub

    Private Sub RedirectToReturnUrl()
        Dim returnUrl As String = Request.QueryString("ReturnUrl")
    End Sub
End Class
