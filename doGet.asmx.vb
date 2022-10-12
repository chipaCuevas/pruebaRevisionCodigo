Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Web.Script.Serialization
Imports CamaraDiputadosAppLibrary.Classes

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")>
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<ToolboxItem(False)>
Public Class doGet
    Inherits System.Web.Services.WebService

    <WebMethod(EnableSession:=True)>
    Public Function validarUsuario(prmRut As Integer) As String
        'Dim vUsuario As Usuario = vUsuario.getDatos(prmRut)
        Dim js As New JavaScriptSerializer

        Dim vResult As New httpResult
        Dim retMensaje As String
        Dim retTurno As String
        Dim retorno As String

        retorno = Usuario.validarUsuario(prmRut, retMensaje, retTurno)


        If Not IsNothing(retorno) Then
            Select Case retMensaje
                Case "1"
                    vResult.result = True
                    vResult.message = "Autorizado"
                    vResult.errorcode = "1"
                Case "2"
                    vResult.result = True
                    vResult.message = "Rut no se encuentra en los registros del servicio de alimentación"
                    vResult.errorcode = "2"
                Case "3"
                    vResult.result = True
                    vResult.message = "Ya existe una reserva para hoy con cargo a su diputado"
                    vResult.errorcode = "3"
                Case "4"
                    vResult.result = True
                    vResult.message = "Este tipo de usuario no puede realizar reservas"
                    vResult.errorcode = "4"
                Case "5"
                    vResult.result = True
                    vResult.message = "Ud. ya posee una reserva par este día en el turno de " + retTurno + ", desea actualizarla?"
                    vResult.errorcode = "5"
                Case "6"
                    vResult.result = True
                    vResult.message = "Ya no es posible actualizar la reserva en el turno de " + retTurno
                    vResult.errorcode = "6"
                Case "7"
                    vResult.result = True
                    vResult.message = "Ud ya emitió un vale de almuerzo para hoy."
                    vResult.errorcode = "7"
                Case "8"
                    vResult.result = True
                    vResult.message = "Ud no tiene una declaración de salud vigente."
                    vResult.errorcode = "8"
            End Select


        Else
            vResult.result = False
            vResult.message = "Error Validando a usuario"
        End If

        js.MaxJsonLength = Int32.MaxValue
        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()
        Return ""
    End Function

    <WebMethod(EnableSession:=True)>
    Public Function getDatosUsuario(prmRut As Integer) As String
        Dim vUsuario As Usuario = vUsuario.getDatos(prmRut)
        Dim js As New JavaScriptSerializer
        Dim vResult As New httpResult
        If Not IsNothing(vUsuario) Then
            vResult.result = True
            vResult.data = vUsuario
        Else
            vResult.result = False
            vResult.message = "Error recuperando datos del usuario"
        End If

        js.MaxJsonLength = Int32.MaxValue
        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()
        Return ""
    End Function

    <WebMethod(EnableSession:=True)>
    Public Function getTurnos() As String
        Dim vTurnos As List(Of Turno) = Turno.getTurnos()
        Dim js As New JavaScriptSerializer
        Dim vResult As New httpResult
        If Not IsNothing(vTurnos) Then
            vResult.result = True
            vResult.data = vTurnos
        Else
            vResult.result = False
            vResult.message = "Error recuperando turnos disponibles"
        End If

        js.MaxJsonLength = Int32.MaxValue
        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()
        Return ""
    End Function

    <WebMethod(EnableSession:=True)>
    Public Function getTurnosXRut(prmRut As Integer) As String
        Dim vTurnos As List(Of Turno) = Turno.getTurnosXRut(prmRut)
        Dim js As New JavaScriptSerializer
        Dim vResult As New httpResult
        If Not IsNothing(vTurnos) Then
            vResult.result = True
            vResult.data = vTurnos
        Else
            vResult.result = False
            vResult.message = "Error recuperando turnos disponibles"
        End If

        js.MaxJsonLength = Int32.MaxValue
        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()
        Return ""
    End Function


    <WebMethod(EnableSession:=True)>
    Public Function getCapacidad(prmIdTurno) As String
        Dim vTurnos As List(Of Turno) = Turno.getCapacidad(prmIdTurno)
        Dim js As New JavaScriptSerializer
        Dim vResult As New httpResult
        If Not IsNothing(vTurnos) Then
            vResult.result = True
            vResult.data = vTurnos
        Else
            vResult.result = False
            vResult.message = "Error recuperando turnos disponibles"
        End If

        js.MaxJsonLength = Int32.MaxValue
        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()
        Return ""
    End Function



End Class