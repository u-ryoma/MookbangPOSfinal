Imports System.Data.SqlClient




Public Class RegisterUser


    Dim conn As New SqlConnection("Server=.\SQLEXPRESS01;Database=POS;Trusted_Connection=True;TrustServerCertificate=True")
    Dim i As Integer
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        addBtn()
        clear()
    End Sub

    Public Sub addBtn()
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            Dim cmd As New SqlCommand("INSERT INTO Users (Name ,Users, Password, Roles) VALUES (@Name ,@Username, @Password, @Role)", conn)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@Name", txtboxName.Text)
            cmd.Parameters.AddWithValue("@Username", txtboxUser.Text)
            cmd.Parameters.AddWithValue("@Password", txtboxPword.Text)
            cmd.Parameters.AddWithValue("@Role", cmboxRole.SelectedItem.ToString())

            i = cmd.ExecuteNonQuery()

            If i > 0 Then
                MsgBox("Account Created!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MsgBox("Account not created", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try



    End Sub

    Public Sub clear()
        txtboxUser.Clear()
        txtboxPword.Clear()
        cmboxRole.SelectedIndex = -1
        txtboxUser.Focus()
        txtboxName.Clear()
    End Sub

    Private Sub txtboxPword_TextChanged(sender As Object, e As EventArgs) Handles txtboxPword.TextChanged
        txtboxPword.PasswordChar = "*"c
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        MsgBox("Are you sure you want to cancel?", MsgBoxStyle.YesNo, "Cancel")
        If MsgBoxResult.Yes Then
            Me.Close()

        End If

    End Sub
End Class