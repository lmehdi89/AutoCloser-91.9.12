Public Class Form4

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TopMost = True
        If Form1.ComboBox1.Text = "sgmain" Then
            Label1.Text = "تا 60 ٍثانیه دیگر برنامه اتوماسیون اداری، به دلیل عدم استفاده شما کاربر محترم، بسته خواهد شد."
        Else
            Label1.Text = "تا 60 ٍثانیه دیگر برنامه " + Form1.ComboBox1.Text + " بسته خواهد شد"
        End If
        Label2.Text = "ادراه آمار و فناوری اطلاعات جهاد کشاورزی استان گیلان"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class