Imports System.Data.OleDb
Public Class BorrowBooks
    ''variables
    Dim conn As OleDbConnection
    Dim cmd As OleDbCommand
    Dim dr As OleDbDataReader
    Dim da As OleDbDataAdapter
    Dim ds As New DataSet
    Dim count As Integer = 0
    Dim table As String = ""

    Private Function check_Duplicate(ByVal MemId As String) As Boolean
        cmd = New OleDbCommand("SELECT * from ItemsBorrowed where itemsBorrowedID= '" & MemId & "'", conn)
        dr = cmd.ExecuteReader
        If dr.Read Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Function generateID() As Boolean
        Dim strID = ""
        Dim check As Boolean = True
        For i As Integer = 1 To 99999

            If i >= 10 Then
                strID = "IB000" & i

            ElseIf i >= 100 Then
                strID = "IB00" & i

            ElseIf i >= 1000 Then
                strID = "IB0" & i

            ElseIf i >= 10000 Then

                strID = "IB" & i
            Else
                strID = "IB0000" & i

            End If

            check = check_Duplicate(strID)
            txtBorrowID.Text = strID
            If check = False Then
                Exit For
            End If
        Next

        Return True


    End Function

    Private Function checkID(ByVal memberID As String) As Boolean

        cmd = New OleDbCommand("SELECT * FROM ItemsBorrowed WHERE memberID = '" & memberID & "'", conn)
        dr = cmd.ExecuteReader

        If dr.Read Then
            Return True
        Else
            Return False
        End If
       
        Return True
    End Function

    'Private Function checkItemsID(ByVal itemsID As String) As Boolean



    '    cmd = New OleDbCommand("SELECT * FROM ItemsBorrowed WHERE itemsID = '" & itemsID & "'", conn)
    '    dr = cmd.ExecuteReader


    '    If dr.Read Then
    '        Return True
    '    Else
    '        Return False
    '    End If

    '    Return True


    'End Function

    Private Sub btnCancle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        AdminPage.Show()
        Me.Close()

    End Sub

    Private Sub BorrowBooks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        lblDate.Text = DateAndTime.DateString

        conn = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\xuan\Desktop\VB Assignment\AssignmentDatabase.accdb")
        conn.Open()
        generateID()
    End Sub
    Private Sub btnBorrow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrow.Click

        If txtMemberID.Text = "" Then
            MessageBox.Show("Please enter memberID", "Error", MessageBoxButtons.OK)
        ElseIf checkID(txtMemberID.Text) = False Then
            MessageBox.Show("MemberID entered is Invalid")
        ElseIf cmbType.Text = "" Then
            MessageBox.Show("Please select the type of books", "Error", MessageBoxButtons.OK)
            Exit Sub

        ElseIf cmbType.Text = "Fiction" Then
            If txtItemsID.Text <> "15A2" And txtItemsID.Text <> "15C38" And txtItemsID.Text <> "10A2" And txtItemsID.Text <> "10B4" Then
                MessageBox.Show("Please enter the correct item ID.")
            Else
                If IsDate(txtDueDate.Text) = False Then
                    MessageBox.Show("Please enter Due Date", "Error", MessageBoxButtons.OK)
                Else
                    MessageBox.Show("Successfully borrowed a book.")
                End If
            End If

        ElseIf cmbType.Text = "Non-Fiction" Then
            If txtItemsID.Text <> "14H23" And txtItemsID.Text <> "13B12" And txtItemsID.Text <> "9A21" And txtItemsID.Text <> "12A24" Then
                MessageBox.Show("Please enter the correct item ID.")
            Else
                If IsDate(txtDueDate.Text) = False Then
                    MessageBox.Show("Please enter Due Date", "Error", MessageBoxButtons.OK)
                Else
                    MessageBox.Show("Successfully borrowed a book.")
                End If
            End If

        ElseIf cmbType.Text = "Reference" Then
            If txtItemsID.Text <> "14A1" And txtItemsID.Text <> "15B3" And txtItemsID.Text <> "15A2" And txtItemsID.Text <> "14E24" Then
                MessageBox.Show("Please enter the correct item ID.")
            Else
                If IsDate(txtDueDate.Text) = False Then
                    MessageBox.Show("Please enter Due Date", "Error", MessageBoxButtons.OK)
                Else
                    MessageBox.Show("Successfully borrowed a book.")
                End If
            End If

        ElseIf cmbType.Text = "Audio Disc" Then
            If txtItemsID.Text <> "15C25" And txtItemsID.Text <> "15C26" And txtItemsID.Text <> "15A1" Then
                MessageBox.Show("Please enter the correct item ID.")
            Else
                If IsDate(txtDueDate.Text) = False Then
                    MessageBox.Show("Please enter Due Date", "Error", MessageBoxButtons.OK)
                Else
                    txtBorrowID.Clear()
                    txtDueDate.Clear()
                    txtItemsID.Clear()
                    txtMemberID.Clear()
                    MessageBox.Show("Successfully borrowed a book.")
                    
                End If
            End If
        End If
    End Sub

    Private Sub cmbType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbType.SelectedIndexChanged

        Dim da As OleDbDataAdapter
        Dim ds As New DataSet
        Dim choice As String
        Dim searchQuery As String

        conn = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\xuan\Desktop\VB Assignment\AssignmentDatabase.accdb")
        conn.Open()

        choice = cmbType.Text
        searchQuery = "SELECT itemsID, title FROM Items WHERE type ='" & choice & "'"
        da = New OleDbDataAdapter(searchQuery, conn)

        da.Fill(ds, "Items")
        dgvSearch.DataSource = ds.Tables(0)



    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        ds.Tables(1).Clear()

    End Sub

    Private Sub cmbType_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbType.SelectedValueChanged

        dgvSearch.DataSource = Nothing
        dgvSearch.Refresh()
        dgvSearch.Rows.Clear()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        generateID()
    End Sub
End Class