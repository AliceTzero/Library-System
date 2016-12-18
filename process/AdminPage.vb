Public Class AdminPage


    Private Sub pbBorrow_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbBorrow.MouseClick
        BorrowBooks.Show()
        Me.Hide()
    End Sub


    
    Private Sub pbReturn_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbReturn.MouseClick
        ReturnBook.Show()
        Me.Hide()
    End Sub

    Private Sub pbReport_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Report.Show()
        Me.Hide()
    End Sub


    Private Sub pbBooks_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbBooks.MouseClick
        LibraryBooks.Show()
        Me.Hide()

    End Sub

    Private Sub mnuBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LOGIN.Show()
        Me.Hide()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LOGIN.Show()
        Me.Close()
    End Sub
End Class
