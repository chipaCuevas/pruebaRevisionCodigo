Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports CamaraDiputadosAppLibrary.Classes
Imports System.Web.Script.Serialization

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class doPost
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function HelloWorld() As String
        Return "Hola a todos"
    End Function

    <WebMethod(EnableSession:=True)>
    Public Function grabarTurno() As String
        Dim js As New JavaScriptSerializer
        Dim vReserva As Reserva

        Try
            vReserva = js.Deserialize(Context.Request.Form("reserva"), GetType(Reserva))
        Catch ex As Exception

        End Try


        Dim vResult As New httpResult
        Dim retMensaje As String

        If vReserva.grabarTurno(retMensaje) Then
            Select Case retMensaje
                Case "1"
                    vResult.result = True
                    vResult.message = "La reserva para el turno seleccionado ha sido registrada"
                Case "2"
                    vResult.result = False
                    vResult.message = "Ya no existe disponiblidad para el turno seleccionado"
                Case "3"
                    vResult.result = False
                    vResult.message = "Ya existe una reserva para hoy con cargo a este diputado"
                Case "4"
                    vResult.result = False
                    vResult.message = "Usuario no está habilitado para realizar reservas"
                Case "5"
                    vResult.result = True
                    vResult.message = "La reserva ha sido actualizada"
                Case "6"
                    vResult.result = False
                    vResult.message = "Ya no es posible actualizar la reserva"
            End Select
            'If retMensaje = "1" Then
            '    vResult.result = True
            '    vResult.message = "La reserva para el turno ha sido registrada"
            'Else
            '    If retMensaje = "2" Then
            '        vResult.result = False
            '        vResult.message = "Ud. no puede reservar turno"
            '    Else
            '        If retMensaje = "3" Then
            '            vResult.result = False
            '            vResult.message = "Ya existe un turno reservado con cargo a este diputado"
            '        End If
            '    End If
            'End If


        Else
            vResult.result = False
            vResult.message = "Error guardando turno"
        End If

        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()

        Return ""
    End Function

    <WebMethod(EnableSession:=True)>
    Public Function anularReserva() As String
        Dim js As New JavaScriptSerializer
        Dim rut As Integer

        Try
            rut = Context.Request.Form("rut")
        Catch ex As Exception

        End Try


        Dim vResult As New httpResult
        Dim retMensaje As String

        If Reserva.anularReserva(rut) Then
            vResult.result = True
            vResult.message = "La reserva fue anulada con éxito"
        Else
            vResult.result = False
            vResult.message = "No fue posible anular la reserva"
        End If

        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()

        Return ""
    End Function

End Class