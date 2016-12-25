Imports System.Data.OleDb
Public Class UserInfo
    Dim x As String = memberid
    Dim conn As OleDbConnection
    Dim cmd As OleDbCommand
    Dim dr As OleDbDataReader
    Dim da As OleDbDataAdapter
    Private Sub UserInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'lblMessage.Visible = False
        'txtName.Enabled = False
        'txtUserID.Enabled = False
        ''txtGender.Enabled = False
        'txtAddress.Enabled = False
        'txtEmail.Enabled = False
        'txtPhone.Enabled = False
        'txtPassword.Enabled = False
        'btnUpdate.Enabled = False

        conn = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\xuan\Desktop\VB Assignment\AssignmentDatabase.accdb")
        conn.Open()
        cmd = New OleDbCommand("select * from Member where memberID='" & x & "'", conn)
        dr = cmd.ExecuteReader
        If dr.Read Then
            txtUserID.Text = dr.GetString(0)
            txtName.Text = dr.GetString(1)
            txtEmail.Text = dr.GetString(2)
            txtAddress.Text = dr.GetString(3)
            'txtGender.Text = dr.GetString(4)
            txtPhone.Text = dr.GetString(5)
            txtPassword.Text = dr.GetString(6)

        End If




    End Sub

    Private Sub mnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lblMessage.Visible = True
        txtAddress.Enabled = True
        txtEmail.Enabled = True
        txtPhone.Enabled = True
        btnUpdate.Enabled = True
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        'cmd = New OleDbCommand("Update Member set email='" & txtEmail.Text & "', address='" & txtAddress.Text & "', phoneNo='" & txtPhone.Text & "', password1='" & txtPassword.Text & "' where studID = '" & x & "'", conn)
        'cmd.ExecuteNonQuery()

        If txtName.Text = "" Then
            MessageBox.Show("Please fill in Name", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtName.Clear()
            txtName.Focus()
            Exit Sub
        ElseIf txtUserID.Text = "" Then
            MessageBox.Show("Please fill in Student ID", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUserID.Focus()
            Exit Sub
        ElseIf txtPassword.Text = "" Then
            MessageBox.Show("Please fill in Password", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Exit Sub
        ElseIf txtPhone.Text = "" Then
            MessageBox.Show("Please fill in Phone", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPhone.Focus()
            Exit Sub
        ElseIf txtEmail.Text = "" Then
            MessageBox.Show("Please fill in Email Address", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtEmail.Focus()
            Exit Sub
        ElseIf txtAddress.Text = "" Then
            MessageBox.Show("Please fill in Address", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPhone.Focus()
            Exit Sub
        Else
            MessageBox.Show("Update Sucessful", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        UserPage.Show()
        Me.Close()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub
End Class