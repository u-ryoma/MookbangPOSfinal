Imports System.Data.SqlClient

Public MustInherit Class ProductOperation

    Protected conn As New SqlConnection("Server=.\SQLEXPRESS01;Database=POS;Trusted_Connection=True;TrustServerCertificate=True")

    ' Base template method
    Public Sub Execute(form As ManageMenu)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            PerformOperation(form)
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    ' Polymorphic method (Overridden by subclasses)
    Protected MustOverride Sub PerformOperation(form As ManageMenu)



End Class
