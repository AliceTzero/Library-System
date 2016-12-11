Imports System.Data.OleDb
Public Class BorrowedBook
    Dim conn As OleDbConnection
    Dim cmd As OleDbCommand
    Dim dr As OleDbDataReader
    Dim da As OleDbDataAdapter
    Dim ds As New DataSet
    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        UserPage.Show()
        Me.Hide()

    End Sub

    Private Sub BorrowedBook_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conn = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\xuan\Desktop\VB Assignment\AssignmentDatabase.accdb")
        conn.Open()
        da = New OleDbDataAdapter("Select * from ItemsBorrowed where memberID ='" & memberid & "'", conn)
        da.Fill(ds, "ItemsBorrowed")
        DataGridView1.DataSource = ds.Tables(0)
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        UserPage.Show()
        Me.Close()

    End Sub
End Class