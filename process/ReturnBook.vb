Imports System.Data.OleDb
Public Class ReturnBook
    Dim conn As OleDbConnection ' connect to DB
    Dim cmd As OleDbCommand ' connect to table
    Dim dr As OleDbDataReader ' temp storage
    Dim da As OleDbDataAdapter
    Dim ds As New DataSet

    Private Function checkID(ByVal memberID As String) As Boolean
        cmd = New OleDbCommand("SELECT * FROM ItemsBorrowed WHERE memberID = '" & memberID & "'", conn)
        dr = cmd.ExecuteReader
        If dr.Read Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub ReturnBook_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conn = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\xuan\Desktop\VB Assignment\AssignmentDatabase.accdb")
        conn.Open()
    End Sub

    Private Sub btnDisplayRecords_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplayRecords.Click
        Dim da As OleDbDataAdapter
        Dim ds As New DataSet

        ''change the button text
        If btnDisplayRecords.Text = "Display Records" Then


            If txtMemberID.Text = "" Then
                MessageBox.Show("Please enter a member ID", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
            ElseIf checkID(txtMemberID.Text) = False Then
                MessageBox.Show("Member ID not found. Please re-enter.")
                txtMemberID.Clear()
            Else
                da = New OleDbDataAdapter("Select i.itemsBorrowedID,itemsID,memberID,borrowDate,returnDate,dueDate,fineAmt from Fine f,ItemsBorrowed i  where i.itemsBorrowedID = f.itemsBorrowedID AND memberID = '" & txtMemberID.Text & "'", conn)
                da.Fill(ds, "Fine, ItemsBorrowed")
                dgvShow.DataSource = ds.Tables(0)
                btnDisplayRecords.Text = "New Record"
                txtMemberID.Enabled = False
            End If

        ElseIf btnDisplayRecords.Text = "New Record" Then
            btnDisplayRecords.Text = "Display Records"
            txtMemberID.Enabled = True
            txtMemberID.Focus()
            txtMemberID.Clear()
            dgvShow.DataSource = Nothing
            dgvShow.Refresh()
            dgvShow.Rows.Clear()
        End If

    End Sub


    Private Sub btnReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReturn.Click
        If txtItemID.Text = "15H21" Or txtItemID.Text = "11U30" Then
            MessageBox.Show("Book has successfully returned!")
            txtItemID.Clear()
            dgvShow.DataSource = Nothing
            dgvShow.Refresh()
            dgvShow.Rows.Clear()
        Else
            MessageBox.Show("Invalid book ID entered.")
            txtItemID.Clear()
        End If
    End Sub



    Private Sub txtMemberID_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtMemberID.MouseClick

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        AdminPage.Show()
        Me.Hide()
    End Sub
End Class