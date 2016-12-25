Public Class UserPage


    Private Sub pbSearch_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbSearch.MouseClick

        Search.Show()
        Me.Hide()

    End Sub

    Private Sub pbBorrow_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbBorrow.MouseClick
        BorrowedBook.Show()
        Me.Hide()

    End Sub


    Private Sub pbOverdue_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)




    End Sub

    Private Sub btnLogout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogout.Click
        LOGIN.Show()
        Me.Hide()
    End Sub


    Private Sub pbEdit_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbEdit.MouseClick
        UserInfo.Show()
        Me.Hide()

    End Sub

   
    Private Sub UserPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub pbSearch_Click(sender As Object, e As EventArgs) Handles pbSearch.Click

    End Sub
End Class