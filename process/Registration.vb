Imports System.Data.OleDb

Public Class RegisterMember
    Dim strName As String
    Dim strEmail As String
    Dim strPwd As String
    Dim Address As String
    Dim strQuestion As String
    Dim strAnswer As String
    Dim strMemId As String
    Dim strGender As String = ""
    Dim strPhoneNo As String
    Dim strConfirmPass As String

    Dim conn As OleDbConnection ' connect to DB
    Dim cmd As OleDbCommand ' connect to table
    Dim dr As OleDbDataReader ' temp storage


    Private Sub RegisterMember_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'AssignmentDatabaseDataSet.Member' table. You can move, or remove it, as needed.
        conn = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\xuan\Desktop\VB Assignment\AssignmentDatabase.accdb")
        conn.Open()




    End Sub

    Private Sub StudIDTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub




    Private Sub btnSignUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSignUp.Click
        
        If txtName.Text = "" Then
            MessageBox.Show("Please fill in Name", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtName.Clear()
            txtName.Focus()
            Exit Sub
        ElseIf txtStuID.Text = "" Then
            MessageBox.Show("Please fill in Student ID", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtStuID.Focus()
            Exit Sub
        ElseIf txtEmail.Text = "" Then
            MessageBox.Show("Please fill in Email Address", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtEmail.Focus()
            Exit Sub
        ElseIf txtPassword.Text = "" Then
            MessageBox.Show("Please fill in Password", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Exit Sub
        ElseIf txtConfirmPass.Text = "" Then
            MessageBox.Show("Please fill in Password", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtConfirmPass.Focus()
        ElseIf txtPhoneNumber.Text = "" Then
            MessageBox.Show("Please fill in Phone Number", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPhoneNumber.Focus()
        ElseIf txtAddress.Text = "" Then
            MessageBox.Show("Please fill in Address", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddress.Focus()
        Else
            MessageBox.Show("Register Sucessful", "Register Sucessful", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtAddress.Text = ""
            txtConfirmPass.Text = ""
            txtEmail.Text = ""
            txtName.Text = ""
            txtPassword.Text = ""
            txtPhoneNumber.Text = ""
            txtStuID.Text = ""



        End If
        rdbMale.Focus()



    End Sub


    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub linkHvAcc_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkHvAcc.LinkClicked
        Me.Close()

        User.Show()


    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Close()
        User.Show()


    End Sub
End Class
