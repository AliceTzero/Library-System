Public Class LOGIN

    Private Sub pbAdmin_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbAdmin.MouseClick
        Administration.Show()
        Me.Hide()

    End Sub

    Private Sub pbUser_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbUser.MouseClick

    End Sub

    Private Sub pbUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbUser.Click
        User.Show()
        Me.Hide()

    End Sub

    Private Sub pbAdmin_Click(sender As Object, e As EventArgs) Handles pbAdmin.Click

    End Sub
End Class
