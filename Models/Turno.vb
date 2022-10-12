Imports CamaraDiputadosAppLibrary.Classes
Imports Oracle.DataAccess.Client
Public Class Turno
    Public Property id As Integer
    Public Property horarioTurno As String
    Public Property capacidad As Integer
    Public Property disponibilidad As Integer
    Public Property comedor As Integer

    Public Shared Function getTurnos() As List(Of Turno)

        Dim vTurnoList As List(Of Turno) = Nothing
        Dim vDataAdapter As New OracleDataAdapter(New OracleCommand("ALIMENTACION.PCK_RESERVARCUPO.getTipoTurno"))

        Dim vDataTable As New DataTable
        Dim vException As New Exception

        Try
            vDataAdapter.SelectCommand.Parameters.Add("retResultado", OracleDbType.RefCursor, ParameterDirection.Output)


            Dim vAdmServer As New AdministrativoServer
            If vAdmServer.getData(vDataAdapter, vDataTable, vException) Then
                vTurnoList = New List(Of Turno)

                For Each vRow As DataRow In vDataTable.Rows
                    vTurnoList.Add(Mapeo(vRow))
                Next
            End If
        Catch ex As Exception
            vTurnoList = Nothing
        Finally
            vDataAdapter.Dispose()
            vDataTable.Dispose()
        End Try

        Return vTurnoList
    End Function


    Public Shared Function getTurnosXRut(prmRut As Integer) As List(Of Turno)

        Dim vTurnoList As List(Of Turno) = Nothing
        Dim vDataAdapter As New OracleDataAdapter(New OracleCommand("ALIMENTACION.PCK_RESERVARCUPO.getTipoTurnoXRut"))

        Dim vDataTable As New DataTable
        Dim vException As New Exception

        Try
            vDataAdapter.SelectCommand.Parameters.Add("prmRut", OracleDbType.Decimal, prmRut, ParameterDirection.Input)
            vDataAdapter.SelectCommand.Parameters.Add("retResultado", OracleDbType.RefCursor, ParameterDirection.Output)


            Dim vAdmServer As New AdministrativoServer
            If vAdmServer.getData(vDataAdapter, vDataTable, vException) Then
                vTurnoList = New List(Of Turno)

                For Each vRow As DataRow In vDataTable.Rows
                    vTurnoList.Add(Mapeo(vRow))
                Next
            End If
        Catch ex As Exception
            vTurnoList = Nothing
        Finally
            vDataAdapter.Dispose()
            vDataTable.Dispose()
        End Try

        Return vTurnoList
    End Function

    Public Shared Function getCapacidad(prmIdTurno As Integer) As List(Of Turno)

        Dim vTurnoList As List(Of Turno) = Nothing
        Dim vDataAdapter As New OracleDataAdapter(New OracleCommand("ALIMENTACION.PCK_RESERVARCUPO.getTipoTurno"))

        Dim vDataTable As New DataTable
        Dim vException As New Exception

        Try
            vDataAdapter.SelectCommand.Parameters.Add("retResultado", OracleDbType.RefCursor, ParameterDirection.Output)


            Dim vAdmServer As New AdministrativoServer
            If vAdmServer.getData(vDataAdapter, vDataTable, vException) Then
                vTurnoList = New List(Of Turno)

                For Each vRow As DataRow In vDataTable.Rows
                    vTurnoList.Add(Mapeo(vRow))
                Next
            End If
        Catch ex As Exception
            vTurnoList = Nothing
        Finally
            vDataAdapter.Dispose()
            vDataTable.Dispose()
        End Try

        Return vTurnoList
    End Function


    Private Shared Function Mapeo(prmRow As DataRow) As Turno
        Dim vTurno As New Turno

        If prmRow.Table.Columns.Contains("TURNOID") Then vTurno.id = prmRow("TURNOID")
        If prmRow.Table.Columns.Contains("HORARIOTURNO") Then vTurno.horarioTurno = prmRow("HORARIOTURNO")
        If prmRow.Table.Columns.Contains("TURNOCAPACIDAD") Then vTurno.capacidad = prmRow("TURNOCAPACIDAD")
        If prmRow.Table.Columns.Contains("DISPONIBILIDAD") Then vTurno.disponibilidad = prmRow("DISPONIBILIDAD")
        If prmRow.Table.Columns.Contains("TCOMID") Then vTurno.comedor = prmRow("TCOMID")


        Return vTurno
    End Function

End Class
