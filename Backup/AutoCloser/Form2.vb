Public Class Form2

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox2.Text <> "" Then
            'MsgBox(TextBox2.Text.GetHashCode)
            SaveSetting("Atcr", "Startup", "pas", TextBox2.Text.GetHashCode)
            Form1.Show()
            Me.Close()

        Else
            MsgBox("لطفا پسورد را وارد کنید", , "خطا")
        End If

    End Sub

    Private Sub Form2_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If GetSetting("Atcr", "Startup", "pas", 0) = 0 Then
            MsgBox("شما قادر به خارج شدن نیستید ابتدا باید پسورد تعیین کنید", , "خطا")
            e.Cancel = True
        Else
            Form1.Enabled = True
        End If
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Button1_Click(sender, e)
        End If
    End Sub
End Class