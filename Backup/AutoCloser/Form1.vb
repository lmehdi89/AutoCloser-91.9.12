Imports Microsoft.Win32
Imports Microsoft.Win32.Registry
Imports System
Public Class Form1
    Public Shared p As Process
    Public Shared r As TimeSpan
    Public Shared d As Integer
    Dim q As Boolean = False
    Public t As Integer
    Public i As Boolean = True
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            SaveSetting("Atcr", "Startup", "true", CheckBox1.Checked)
            SaveSetting("Atcr", "Startup", "name", ComboBox1.Text)
            SaveSetting("Atcr", "Startup", "time", NumericUpDown1.Value)
            SaveSetting("Atcr", "Startup", "q", True)
            q = True
            Me.Hide()
            ' NotifyIcon1.Icon=
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
    End Sub

    Private Sub ComboBox1_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.DropDown
        Try
            ComboBox1.Items.Clear()
            For Each p As Process In Process.GetProcesses
                ComboBox1.Items.Add(p.ProcessName.ToLower())
            Next
            ComboBox1.Sorted = True

        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        If CheckBox1.Checked Then
            If ComboBox1.Text <> "" And q Then
                For Each p As Process In Process.GetProcesses
                    If p.ProcessName.ToLower() = ComboBox1.Text Then

                        If p.TotalProcessorTime = r Then
                            d += 1
                        Else
                            i = True
                            r = p.TotalProcessorTime
                            d = 0
                            t = NumericUpDown1.Value
                        End If
                        Label1.Text = d
                        If d > t Then
                            If i Then
                                Form4.Show()
                                t += 60
                                i = False
                                GoTo y

                            End If
                            p.Kill()
                            i = True
                            t = 0
y:
                        End If
                    End If
                Next
            End If
        End If

    End Sub

    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        NotifyIcon1.Icon = Nothing
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '  e.Cancel = True
        Me.Hide()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            TMListViewDelete.Running = True
            If Not Me.NotifyIcon1.Visible Then
                Me.NotifyIcon1.Visible = True
                Dim registry As Microsoft.Win32.RegistryKey
                registry = CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True)
                registry.SetValue("Atcr", Application.ExecutablePath)
                Me.ShowInTaskbar = False
                If GetSetting("Atcr", "Startup", "first", 0) = 0 Then
                    Form2.Label1.Text = "پسورد اولیه"
                    Me.Hide()
                    Form2.Show()
                    Form2.BringToFront()
                Else
                    Me.Hide()
                End If
                CheckBox1.Checked = GetSetting("Atcr", "Startup", "true", False)
                ComboBox1.Text = GetSetting("Atcr", "Startup", "name", "")
                NumericUpDown1.Value = GetSetting("Atcr", "Startup", "time", 0)
                SaveSetting("Atcr", "Startup", "first", 1)
                SaveSetting("Atcr", "Startup", "text", "بسته می شود برای جلوگیری از این اقدام برروی صفحه اصلی برنامه کلیک کنید")
                q = GetSetting("Atcr", "Startup", "q", False)
                t = NumericUpDown1.Value
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            ComboBox1.Enabled = True
            NumericUpDown1.Enabled = True
        Else
            ComboBox1.Enabled = False
            NumericUpDown1.Enabled = False
        End If
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Form3.Show()
        Me.Hide()
        Form3.BringToFront()
        Form3.Button1.Visible = True
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Form3.Show()
        Me.Enabled = False
        Form3.BringToFront()
        Form3.Button2.Visible = True
    End Sub

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown1.ValueChanged
        Label1.Text = 0
    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click
        If Label6.Visible Then
            Label6.Visible = False
        Else
            Label6.Visible = True
            Label6.Size = New Size(102, 13)
        End If
    End Sub

    Private Sub Label12_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Me.Size = New Size(286, 276)
    End Sub

    Private Sub Label14_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Me.Size = New Size(286, 200)
    End Sub

    Private Sub TabPage2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage2.Leave
        Me.Size = New Size(286, 200)
    End Sub
    Private Sub TabPage1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage1.Leave
        Me.Size = New Size(286, 276)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'registry = CurrentUser.OpenSubKey("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\{93998800-1608-403F-9A51-420A77D23C25}", True)
        '   registry.DeleteSubKeyTree("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\{93998800-1608-403F-9A51-420A77D23C25}")
        'RegDeleteKey&(0, "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\{93998800-1608-403F-9A51-420A77D23C25}")
        'registry.DeleteKey(0, "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\IEData")

        'registry.DeleteSubKey("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\{93998800-1608-403F-9A51-420A77D23C25}")
        Dim re As RegistryKey
        re = Registry.LocalMachine.OpenSubKey("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall", True)
        re.DeleteSubKey("{93998800-1608-403F-9A51-420A77D23C25}")
        re.Close()
        MsgBox("غیر فعال شد")
    End Sub
End Class
