Imports System.Data.OleDb
Public Class Administration
    Dim conn As OleDbConnection
    Dim cmd As OleDbCommand
    Dim dr As OleDbDataReader

    Private Function check_PWID(ByVal AdminUser As String, ByVal AdminPw As String) As Boolean
        cmd = New OleDbCommand("SELECT * from Staff where username = '" & AdminUser & "' and password = '" & AdminPw & "'", conn)
        dr = cmd.ExecuteReader
        If dr.Read Then

            Return True

        Else
            Return False
        End If

        
    End Function

    Private Sub linkForgot_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

        Me.Hide()
    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click

        Dim Check As Boolean = False

        If txtName.Text = "" Then

            MessageBox.Show("This field(Login ID) cannot be Empty", "Input Error", MessageBoxButtons.OK)
            txtName.Focus()
        ElseIf txtPassword.Text = "" Then
            MessageBox.Show("This field(Password) cannot be Empty", "Input Error", MessageBoxButtons.OK)
            txtPassword.Focus()
        Else
            Check = check_PWID(CStr(txtName.Text), CStr(txtPassword.Text))
            If Check = False Then
                MessageBox.Show("The username and password you entered don't match.", "Login Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtName.Clear()
                txtPassword.Clear()
                txtName.Focus()

            ElseIf Check = True Then
                staffID = txtName.Text
                staffPwd = txtPassword.Text
                AdminPage.Show()
                Me.Close()
            End If

        End If
        
    End Sub

    Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
        LOGIN.Show()
        Me.Close()

    End Sub

    Private Sub mnuClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClear.Click
        txtName.Clear()
        txtPassword.Clear()

    End Sub

    Private Sub Administration_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conn = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\xuan\Desktop\VB Assignment\AssignmentDatabase.accdb")
        conn.Open()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Close()

        LOGIN.Show()
    End Sub
End Class
