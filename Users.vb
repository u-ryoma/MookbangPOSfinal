Imports System.Data.SqlClient

Public Class Users
    Dim conn As New SqlConnection("Server=.\SQLEXPRESS01;Database=POS;Trusted_Connection=True;TrustServerCertificate=True")
    Public Sub DGV_load()

        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.Rows.Clear()
        Dim conn As New SqlConnection("Server=.\SQLEXPRESS01;Database=POS;Trusted_Connection=True;TrustServerCertificate=True")
        Dim dr As SqlDataReader

        Try
            conn.Open()
            Dim cmd As New SqlCommand("SELECT * FROM Users", conn)
            dr = cmd.ExecuteReader()

            Dim totalSum As Decimal = 0

            While dr.Read
                DataGridView1.Rows.Add(
                    dr("Name"),
                    dr("Users"),
                    dr("Password"),
                    dr("Roles"))



            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub History_staff_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DGV_load()
    End Sub

End Class
