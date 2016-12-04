Public Class CalculateFine
    Dim fine As Double = 0.0
    Dim payment As Double = 0.0
    Dim remainder As Double = 0.0
    Private Sub CalculateFine_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtTotalFines.Enabled = False
        totalDayOverdue.Enabled = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalculate.Click
        Dim Date1 As Date
        Dim Date2 As Date

        Dim totalDays As Integer = 0
        Dim totalOverdue As Integer = 0

        Dim rate As Double = 0.5
        Date1 = txtReturnDate.Text
        Date2 = txtCurrentDate.Text

        
        totalDays = DateDiff(DateInterval.Day, Date1, Date2)
        txtTotalDays.Text = totalDays.ToString
        totalOverdue = totalDays - 5

        If totalDays > 5 Then
            fine = (totalDays - 5) * rate
            txtTotalFines.Text = fine.ToString("C2")
            totalDayOverdue.Text = totalOverdue.ToString
        End If

        'Here "d" is used to set interval to days
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        payment = InputBox("Enter Payment Amount RM:")

        If payment >= fine Then
            remainder = payment - fine
            MessageBox.Show("Payment Successful" & vbCrLf & "Remain :" & remainder, "Payment Clear", MessageBoxButtons.OK)
        ElseIf payment < fine Then
            remainder = fine - payment
            MessageBox.Show("Insufficient Money" & vbCrLf & "Require Rm: " & remainder, "", MessageBoxButtons.OK)
        End If


        
    End Sub
End Class
