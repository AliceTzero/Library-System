Imports System.Data.OleDb
Public Class AddBookForm

    Dim cmd As OleDbCommand
    Dim conn As OleDbConnection
    Dim dr As OleDbDataReader

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        LibraryBooks.Show()
        Me.Hide()

    End Sub

    Private Sub AddBookForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conn = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\xuan\Desktop\VB Assignment\AssignmentDatabase.accdb")
        conn.Open()

        'txtName.Enabled = False
        'txtIBSN.Enabled = False
        'txtItem.Enabled = False
        'txtPubID.Enabled = False
        'cmbType.Enabled = False
        'YearOfPublish.Enabled = False

        'cmbType.SelectedIndex = 0
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim title As String = CStr(txtName.Text)
        Dim Type As String = CStr(cmbType.Text)
        Dim ISBN As String = 0
        Dim ItemID As String = CStr(txtItem.Text)
        Dim PublisherId As String = CStr(txtPubID.Text)
        Dim datez As String = CStr(YearOFPublish.Text)
        ISBN = CStr(txtIBSN.Text).ToString

        If txtName.Text = "" Or txtIBSN.Text = "" Or txtItem.Text = "" Or txtPubID.Text = "" Or cmbType.Text = "" Or IsDate(YearOFPublish.Text) = False Then
            MessageBox.Show("Please enter all the required fields", "Reminder", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else

            MessageBox.Show("Successfully added a book!")
            txtIBSN.Text = ""
            txtItem.Text = ""
            cmbType.SelectedIndex = 0
            txtName.Text = ""
            txtPubID.Text = ""
            YearOFPublish.Text = ""
        End If


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class