Imports System.Data.OleDb
Public Class Report
    Dim conn As OleDbConnection
    Dim cmd As OleDbCommand
    Dim dr As OleDbDataReader
    Dim da As OleDbDataAdapter

    Dim duedate As Date
    Dim memberid As String = ""
    Dim memberName As String = ""
    Dim itemsID As String = ""
    Dim title As String = ""
    Dim date1 As Date
    Dim date2 As Date
    Dim splitYear As String = ""

    Dim fineID As String = ""
    Dim fineAmt As Double = 0
    Dim itemsBorrowedID As String = ""
    Dim ibsnNo As String = ""
    Dim bookTitle As String = ""
    Private Function check_Format(ByVal MemId As String) As String

        Dim i As Integer = 0
        Dim count As Integer = 0
        Dim year As String = ""
        '   strChar = MemId.Substring(0, 2) ' CL00015  = CL
        '  intNum = MemId.Substring(2, 5)  ' CL00015  = 00015
        year = MemId.Substring(2, 2)

        Return year

    End Function

    Private Sub mnuBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AdminPage.Show()
        Me.Hide()

    End Sub

    Private Sub Report_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conn = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\xuan\Desktop\VB Assignment\AssignmentDatabase.accdb")
        conn.Open()
        txtdate1.Enabled = False
        txtdate2.Enabled = False
        cmbYear.Enabled = False
        
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If cmbReportType.SelectedItem = "OVERDUE" Then
            PrintPreviewDialog1.Document = PrintDocument1
            PrintPreviewDialog1.ShowDialog()
        ElseIf cmbReportType.SelectedItem = "BOOKS ADDED IN A YEAR" Then
            PrintPreviewDialog1.Document = PrintDocument2
            PrintPreviewDialog1.ShowDialog()
        ElseIf cmbReportType.SelectedItem = "FINES REPORT" Then
            PrintPreviewDialog1.Document = PrintDocument3
            PrintPreviewDialog1.ShowDialog()
        
        End If
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim myFont As New Font("Arial", 20, FontStyle.Bold)
        Dim myFont1 As New Font("Arial", 16)
        Dim myFont2 As New Font("Arial", 12)
        Dim x As Single = e.MarginBounds.Left
        Dim y As Single = e.MarginBounds.Top
        Dim linespace As Single = myFont.GetHeight


        'txtdate1.Text = date1
        'txtdate2.Text = date2
        date1 = Format(CDate(txtdate1.Text).Date, "MM/dd/yyyy")
        date2 = Format(CDate(txtdate2.Text).Date, "MM/dd/yyyy")

        'DateTime.TryParse(txtdate1.Text, date1)
        'DateTime.TryParse(txtdate2.Text, date2)


        e.Graphics.DrawString("NLB College Library Management System", myFont, Brushes.Black, x + 60, y)
        y += linespace
        e.Graphics.DrawString("Overdue Books List", myFont, Brushes.Black, x + 170, y)
        y += linespace * 1.1
        e.Graphics.DrawString("Ending Date :   " & date2, myFont1, Brushes.Black, x + 190, y)
        y += linespace
        y += linespace * 0.1

        y += linespace
        e.Graphics.DrawString("Member ID        Due Date       Member Name             Title           ", myFont2, Brushes.Black, x, y)
        y += linespace * 0.2
        e.Graphics.DrawString("____________________________________________________________________", myFont2, Brushes.Black, x, y)
        y += linespace

        cmd = New OleDbCommand("select memberName, m.memberID, dueDate, title from Member m , ItemsBorrowed ib, Items i where m.memberID = ib.memberID And ib.itemsID = i.itemsID And borrowDate between #" & date1 & "# and #" & date2 & "# ", conn)
        dr = cmd.ExecuteReader

        While dr.Read

            duedate = dr.GetDateTime(2)
            memberid = dr.GetString(1)
            title = dr.GetString(3)
            memberName = dr.GetString(0)

            e.Graphics.DrawString(memberid, myFont2, Brushes.Black, x, y)
            e.Graphics.DrawString(duedate, myFont2, Brushes.Black, x + 120, y)
            e.Graphics.DrawString(memberName, myFont2, Brushes.Black, x + 230, y)
            e.Graphics.DrawString(title, myFont2, Brushes.Black, x + 400, y)
            y += linespace
        End While



    End Sub

    Private Sub PrintDocument2_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument2.PrintPage
        Dim myFont As New Font("Arial", 20, FontStyle.Bold)
        Dim myFont1 As New Font("Arial", 16)
        Dim myFont2 As New Font("Arial", 12)
        Dim x As Single = e.MarginBounds.Left
        Dim y As Single = e.MarginBounds.Top
        Dim linespace As Single = myFont.GetHeight


        e.Graphics.DrawString("NLB College Library Management System", myFont, Brushes.Black, x + 60, y)
        y += linespace
        e.Graphics.DrawString("Books added in a year", myFont, Brushes.Black, x + 170, y)
        y += linespace * 1.1
        e.Graphics.DrawString("Ending Date :   " & cmbYear.SelectedItem, myFont1, Brushes.Black, x + 190, y)
        y += linespace
        y += linespace * 0.1

        e.Graphics.DrawString("Items ID     ISBN No.                   Book Title", myFont2, Brushes.Black, x, y)
        y += linespace * 0.2
        e.Graphics.DrawString("____________________________________________________________________", myFont2, Brushes.Black, x, y)
        y += linespace

        itemsID = check_Format(cmbYear.SelectedItem)

        cmd = New OleDbCommand("select ib.itemsID, title,ibsnNo from Items i,ItemsBorrowed ib where i.itemsID=ib.itemsID AND ib.itemsID LIKE '" & itemsID & "%'", conn)
        dr = cmd.ExecuteReader

        While dr.Read
            itemsID = dr.GetString(0)
            ibsnNo = dr.GetString(2)
            title = dr.GetString(1)


            e.Graphics.DrawString(itemsID, myFont2, Brushes.Black, x, y)
            e.Graphics.DrawString(ibsnNo, myFont2, Brushes.Black, x + 80, y)
            e.Graphics.DrawString(title, myFont2, Brushes.Black, x + 240, y)

            y += linespace

        End While
    End Sub

    Private Sub PrintDocument3_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument3.PrintPage
        Dim myFont As New Font("Arial", 20, FontStyle.Bold)
        Dim myFont1 As New Font("Arial", 16)
        Dim myFont2 As New Font("Arial", 12)
        Dim x As Single = e.MarginBounds.Left
        Dim y As Single = e.MarginBounds.Top
        Dim linespace As Single = myFont.GetHeight


        splitYear = check_Format(cmbYear.SelectedItem)

        e.Graphics.DrawString("NLB College Library Management System", myFont, Brushes.Black, x + 60, y)
        y += linespace
        e.Graphics.DrawString("Fine Report", myFont, Brushes.Black, x + 240, y)
        y += linespace * 1.1

        y += linespace
        e.Graphics.DrawString("Member ID        Items Borrowed ID           Fine ID             Fine Amount<RM>", myFont2, Brushes.Black, x, y)
        y += linespace * 0.2
        e.Graphics.DrawString("____________________________________________________________________", myFont2, Brushes.Black, x, y)
        y += linespace

        cmd = New OleDbCommand("SELECT DISTINCT ib.memberID, f.itemsBorrowedID, fineID, fineAmt FROM Member m, Items i, ItemsBorrowed ib, Fine f WHERE m.memberID = ib.memberID AND ib.itemsBorrowedID = f.itemsBorrowedID  AND fineID LIKE '" & splitYear & "%' Order by fineAmt asc", conn)
        dr = cmd.ExecuteReader


        While dr.Read
            memberid = dr.GetString(0)
            itemsBorrowedID = dr.GetString(1)
            fineID = dr.GetString(2)
            fineAmt = dr.GetDouble(3)

            e.Graphics.DrawString(memberid, myFont2, Brushes.Black, x, y)
            e.Graphics.DrawString(itemsBorrowedID, myFont2, Brushes.Black, x + 130, y)
            e.Graphics.DrawString(fineID, myFont2, Brushes.Black, x + 320, y)
            e.Graphics.DrawString(fineAmt, myFont2, Brushes.Black, x + 490, y)
            y += linespace
        End While

    End Sub

    Private Sub cmbReportType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbReportType.SelectedIndexChanged
        If cmbReportType.SelectedItem = "OVERDUE" Then
            txtdate1.Enabled = True
            txtdate2.Enabled = True
            cmbYear.Enabled = False
            txtdate1.Focus()
        ElseIf cmbReportType.SelectedItem = "BOOKS ADDED IN A YEAR" Then
            txtdate1.Enabled = False
            txtdate2.Enabled = False
            cmbYear.Enabled = True
        ElseIf cmbReportType.SelectedItem = "FINES REPORT" Then
            txtdate1.Enabled = False
            txtdate2.Enabled = False
            cmbYear.Enabled = True
        End If
    End Sub

   
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        cmd = New OleDbCommand("SELECT ib.memberID, f.itemsBorrowedID, fineID, fineAmt FROM Member m, Items i, ItemsBorrowed ib, Fine f WHERE m.memberID = ib.memberID AND ib.itemsBorrowedID = f.itemsBorrowedID  AND fineID LIKE '" & splitYear & "%'", conn)
        dr = cmd.ExecuteReader
    End Sub
End Class