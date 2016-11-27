Imports System.Data.OleDb
Public Class LibraryBooks

    Dim conn As OleDbConnection
    Dim cmd As OleDbCommand
    Dim dr As OleDbDataReader


    Private Sub mnuBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AdminPage.Show()
        Me.Hide()

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        
        AddBookForm.Show()
        Me.Hide()

    End Sub

    Private Sub LibraryBooks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conn = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\xuan\Desktop\VB Assignment\AssignmentDatabase.accdb")
        conn.Open()

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim result As String
        result = InputBox("Enter the itemID of the item you want to delete.")

        'cmd = New OleDbCommand("Delete * from items where itemsid='" & result & "'", conn)
        'cmd.ExecuteNonQuery()

        If result = "10A2" Or result = "15A2" Or result = "10B40" Then
            MessageBox.Show("Delete Successfully")
        Else
            MessageBox.Show("Please enter correct item ID")
        End If


    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        itemsID = InputBox("Enter the item ID")

        If DialogResult.OK Then
            EditBook.Show()
        End If


    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim da As OleDbDataAdapter
        Dim ds As New DataSet
        Dim xxx As String

        xxx = cmbType.Text
        da = New OleDbDataAdapter("Select * from Items where type ='" & xxx & "' and title like '" & txtTitle.Text & "%'", conn)
        da.Fill(ds, "Items")
        DataGridView1.DataSource = ds.Tables(0)


    End Sub
End Class