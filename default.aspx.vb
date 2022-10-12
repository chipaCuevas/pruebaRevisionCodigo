Imports CamaraDiputadosAppLibrary.Classes
Public Class _default
    Inherits System.Web.UI.Page
    Public Usuario As User
    Public preventCache As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'PARA CAMBIAR A DESARROLLO / PRODUCCION SE DEBE REALIZAR UNA SOLVEZ AL INICIO DEL PROYECTO
        Dim vUser As Usuario = Nothing
        preventCache = Date.Now.ToString("yyyyMMddHHmmss")
        AdministrativoServer.enProduccion = True

        If AdministrativoServer.enProduccion Then
            Usuario = New User("alimentacion", "sec")
            Usuario.Name = "alimentacion"
            Usuario.LastName = " de producción"
        Else
            Usuario = New User("ALIMENTACION", "alimentacion")
            Usuario.Name = "alimentacion"
            Usuario.LastName = " de desarrollo"
        End If
        AdministrativoServer.User = Usuario
    End Sub

End Class