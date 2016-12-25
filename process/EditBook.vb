Imports System.Data.OleDb
Public Class EditBook

    Dim conn As OleDbConnection
    Dim cmd As OleDbCommand
    Dim dr As OleDbDataReader
    Dim da As OleDbDataAdapter
    Dim ds As New DataSet

    Private Sub EditBook_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conn = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\xuan\Desktop\VB Assignment\AssignmentDatabase.accdb")
        conn.Open()
        cmd = New OleDbCommand("select * from Items where itemsID='" & itemsID & "'", conn)
        dr = cmd.ExecuteReader
        If dr.Read Then
            txtItem.Text = dr.GetString(0)
            txtPubID.Text = dr.GetString(1)
            YearOFPublish.Text = dr.GetString(2)
            txtName.Text = dr.GetString(3)
            txtMaskIBSN.Text = dr.GetString(4)
            cmbType.Text = dr.GetString(5)
            txtItem.Enabled = False
        Else
            MessageBox.Show("Item ID not Found. Please re-enter.")
            Me.Close()
            LibraryBooks.Show()
        End If


    End Sub




    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If txtMaskIBSN.Text = "" Then
            MessageBox.Show("Please enter the IBSN Number.", "Error", MessageBoxButtons.OK)
        ElseIf txtItem.Text = "" Then
            MessageBox.Show("Please enter the Items ID.", "Error", MessageBoxButtons.OK)
        ElseIf txtName.Text = "" Then
            MessageBox.Show("Please enter the title.", "Error", MessageBoxButtons.OK)
        ElseIf txtPubID.Text = "" Then
            MessageBox.Show("Please enter the publisher ID.", "Error", MessageBoxButtons.OK)
        ElseIf cmbType.Text = "" Then
            MessageBox.Show("Please enter the type of books.", "Error", MessageBoxButtons.OK)
        ElseIf YearOFPublish.Text = "" Then
            MessageBox.Show("Please enter the year of publish.", "Error", MessageBoxButtons.OK)
        Else
            cmd = New OleDbCommand("Update items set pubID='" & txtPubID.Text & "', pubDate='" & YearOFPublish.Text & "', title='" & txtName.Text & "', ibsnNo='" & txtMaskIBSN.Text & "', type='" & cmbType.Text & "' where itemsID = '" & itemsID & "'", conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Successfully edited a book!")
        End If

        
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        LibraryBooks.Show()
        Me.Close()
    End Sub
End Class
