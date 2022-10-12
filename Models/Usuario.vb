Imports CamaraDiputadosAppLibrary.Classes
Imports Oracle.DataAccess.Client
Public Class Usuario
    Public Property rut As Integer
    Public Property nombre As String
    Public Property parid As Integer
    Public Property nombreDiputado As String
    Public Property turnoReserva As Integer
    Public Property cantidadEmpleador As Integer
    Public Property Diputados As List(Of Diputado)

    Public Shared Function getDatos(prmRut As Integer) As Usuario

        getDatos = New Usuario

        Dim vDataAdapter As New OracleDataAdapter(New OracleCommand("ALIMENTACION.PCK_RESERVARCUPO.getDatosUsuarios"))
        vDataAdapter.SelectCommand.Parameters.Add("prmRut", OracleDbType.Varchar2, Nothing, prmRut.ToString, ParameterDirection.Input)
        vDataAdapter.SelectCommand.Parameters.Add("retResultado", OracleDbType.RefCursor, ParameterDirection.Output)

        Dim vServer As New AdministrativoServer
        Dim vDataTable As New DataTable
        Dim ex As Exception

        Dim vRow As DataRow
        If vServer.getData(vDataAdapter, vRow, ex) Then
            getDatos = Mapeo(vRow)
        End If
        vDataAdapter.Dispose()
        vDataTable.Dispose()
        Return getDatos

    End Function

    Public Shared Function validarUsuario(prmRut As Integer, ByRef retMensaje As String, ByRef retTurno As String) As String


        Dim cmd As New OracleCommand("ALIMENTACION.PCK_RESERVARCUPO.validarUsuario")
        cmd.Parameters.Add("prmRut", OracleDbType.Varchar2, Nothing, prmRut.ToString, ParameterDirection.Input)
        cmd.Parameters.Add("retMensaje", OracleDbType.Decimal, ParameterDirection.Output)
        cmd.Parameters.Add("retTurno", OracleDbType.Varchar2, 100, Nothing, ParameterDirection.Output)

        Dim vServer As New AdministrativoServer
        Dim vDataTable As New DataTable
        Dim ex As Exception

        If vServer.ExecuteCommand(cmd, ex) Then
            retMensaje = cmd.Parameters("retMensaje").Value.ToString()
            If cmd.Parameters("retTurno").Value IsNot Nothing Then
                retTurno = cmd.Parameters("retTurno").Value.ToString
            Else
                retTurno = ""
            End If
            vDataTable.Dispose()
            Return True
            'Else
            '    Return "0"
        End If
        Return False
    End Function

    Private Shared Function Mapeo(prmRow As DataRow) As Usuario
        Dim vUsuario As New Usuario

        If prmRow.Table.Columns.Contains("NOMBRE") Then vUsuario.nombre = prmRow("NOMBRE")
        If prmRow.Table.Columns.Contains("ID_DIP") Then vUsuario.parid = prmRow("ID_DIP")
        If prmRow.Table.Columns.Contains("RUT") Then vUsuario.rut = prmRow("RUT")
        If Not IsDBNull(prmRow("DIPUTADO")) Then
            If prmRow.Table.Columns.Contains("DIPUTADO") Then vUsuario.nombreDiputado = prmRow("DIPUTADO")
        End If
        If Not IsDBNull(prmRow("RESERVATURNO")) Then
            If prmRow.Table.Columns.Contains("RESERVATURNO") Then vUsuario.turnoReserva = prmRow("RESERVATURNO")
        End If
        If Not IsDBNull(prmRow("CANTIDADEMPLEADOR")) Then
            If prmRow.Table.Columns.Contains("CANTIDADEMPLEADOR") Then vUsuario.cantidadEmpleador = prmRow("CANTIDADEMPLEADOR")
        End If
        If vUsuario.cantidadEmpleador = 2 Then
            vUsuario.Diputados = Diputado.getEmpleadores(vUsuario.rut)
        End If
        Return vUsuario
    End Function

End Class
