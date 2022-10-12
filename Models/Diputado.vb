Imports CamaraDiputadosAppLibrary.Classes
Imports Oracle.DataAccess.Client

Public Class Diputado
    Public Property idDip As Integer
    Public Property Nombre As String
    Public Property CupoDisponible As Integer

    Public Shared Function getEmpleadores(prmRut As Integer) As List(Of Diputado)

        Dim vEmpleadoresList As List(Of Diputado) = Nothing
        'Dim vDataAdapter As New OracleDataAdapter(New OracleCommand("RECEPCION2013.PCK_SOLICITUD_VISITA_TURNOS.getTurnos"))
        Dim vDataAdapter As New OracleDataAdapter(New OracleCommand("ALIMENTACION.PCK_RESERVARCUPO.getEmpleadores"))

        Dim vDataTable As New DataTable
        Dim vException As New Exception

        Try

            vDataAdapter.SelectCommand.Parameters.Add("prmRut", OracleDbType.Decimal, prmRut, ParameterDirection.Input)
            vDataAdapter.SelectCommand.Parameters.Add("retResultado", OracleDbType.RefCursor, ParameterDirection.Output)



            Dim vAdmServer As New AdministrativoServer
            If vAdmServer.getData(vDataAdapter, vDataTable, vException) Then
                vEmpleadoresList = New List(Of Diputado)

                For Each vRow As DataRow In vDataTable.Rows
                    vEmpleadoresList.Add(Mapeo(vRow))
                Next
            End If
        Catch ex As Exception
            vEmpleadoresList = Nothing
        Finally
            vDataAdapter.Dispose()
            vDataTable.Dispose()
        End Try

        Return vEmpleadoresList
    End Function
    Public Shared Function getCupoEmpleador(prmIdDip As Integer) As Integer

        Dim vCupo As Integer = 0
        Dim cmd As New OracleCommand("ALIMENTACION.PCK_RESERVARCUPO.getCupoEmpleador")

        cmd.Parameters.Add("prmIdDip", OracleDbType.Decimal, prmIdDip, ParameterDirection.Input)
        cmd.Parameters.Add("retCupo", OracleDbType.Decimal, ParameterDirection.Output)


        Dim vAdmServer As New AdministrativoServer
        Dim ex As New Exception

        'Dim ok As Boolean = vAdmServer.ExecuteCommand(cmd, ex)
        If vAdmServer.ExecuteCommand(cmd, ex) Then
            vCupo = CInt(Int(cmd.Parameters("retCupo").Value.ToString))
            cmd.Dispose()
            Return vCupo
            'Else
            '    Return "0"
        End If

        Return vCupo
    End Function

    Private Shared Function Mapeo(prmRow As DataRow) As Diputado
        Dim vEmpleador As New Diputado

        If prmRow.Table.Columns.Contains("NOMBRE") Then vEmpleador.Nombre = prmRow("NOMBRE")
        If prmRow.Table.Columns.Contains("IDDIP") Then
            vEmpleador.idDip = prmRow("IDDIP")
            vEmpleador.CupoDisponible = getCupoEmpleador(vEmpleador.idDip)
        End If

        Return vEmpleador
    End Function
End Class
