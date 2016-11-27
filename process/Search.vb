Imports System.Data.OleDb

Public Class Search

    Dim conn As OleDbConnection
    Dim dr As OleDbDataReader
    Dim da As OleDbDataAdapter
    Dim cmd As OleDbCommand
    Dim ds As New DataSet

    Private Sub btnCancle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        UserPage.Show()
        Me.Hide()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim xxx As String

        xxx = cmbType.Text
        da = New OleDbDataAdapter("Select * from Items where type = '" & xxx & "' and title like '" & txtTitle.Text & "%'", conn)
        da.Fill(ds, "Items")
        DataGridView1.DataSource = ds.Tables(0)


    End Sub

    Private Sub Search_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conn = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\xuan\Desktop\VB Assignment\AssignmentDatabase.accdb")
        conn.Open()
    End Sub
End Class