Imports CamaraDiputadosAppLibrary.Classes
Imports Oracle.DataAccess.Client
Public Class Reserva
    Public Property rut As Integer
    Public Property turno As Turno
    Public Property idDip As Integer


    Friend Function grabarTurno(ByRef retMensaje As String) As Boolean
        Dim context As System.Web.HttpContext = System.Web.HttpContext.Current
        Dim ipcompleta As String = context.Request.ServerVariables("REMOTE_ADDR")
        Dim cmd As New OracleCommand("ALIMENTACION.PCK_RESERVARCUPO.registrarTurno")

        cmd.Parameters.Add("prmRut", OracleDbType.Decimal, Me.rut, ParameterDirection.Input)
        cmd.Parameters.Add("prmTurnoId", OracleDbType.Decimal, Me.turno.id, ParameterDirection.Input)
        cmd.Parameters.Add("prmIP", OracleDbType.Varchar2, ipcompleta, ParameterDirection.Input)
        cmd.Parameters.Add("prmComedor", OracleDbType.Decimal, Me.turno.comedor, ParameterDirection.Input)
        cmd.Parameters.Add("prmIdDip", OracleDbType.Decimal, Me.idDip, ParameterDirection.Input)
        cmd.Parameters.Add("retMensaje", OracleDbType.Decimal, ParameterDirection.Output)


        Dim vAdmServer As New AdministrativoServer
        Dim ex As New Exception

        'Dim ok As Boolean = vAdmServer.ExecuteCommand(cmd, ex)
        If vAdmServer.ExecuteCommand(cmd, ex) Then
            retMensaje = cmd.Parameters("retMensaje").Value.ToString()
            cmd.Dispose()
            Return True
            'Else
            '    Return "0"
        End If

        Return False
    End Function

    Shared Function anularReserva(prmRut As Integer) As Boolean
        Dim cmd As New OracleCommand("ALIMENTACION.PCK_RESERVARCUPO.anularReserva")

        cmd.Parameters.Add("prmRut", OracleDbType.Decimal, prmRut, ParameterDirection.Input)


        Dim vAdmServer As New AdministrativoServer
        Dim ex As New Exception

        'Dim ok As Boolean = vAdmServer.ExecuteCommand(cmd, ex)
        If vAdmServer.ExecuteCommand(cmd, ex) Then
            cmd.Dispose()
            Return True
            'Else
            '    Return "0"
        End If

        Return False
    End Function

End Class
