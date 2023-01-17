Imports Microsoft.Win32
Public Class Form3

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Try
            If TextBox2.Text <> "" Then
                If TextBox2.Text.GetHashCode = GetSetting("Atcr", "Startup", "pas", 0) Then
                    Form1.Show()
                    Me.Close()
                    Form1.Enabled = True
                ElseIf TextBox2.Text = "Uninstall" And Form1.Button3.Enabled = False Then
                    CUN()
                    SaveSetting("Atcr", "Startup", "Unin", 0)
                Else

                    MsgBox("برای ورود احتیاج به پسورد صحیح دارید", , "خطا")
                End If
            Else
                MsgBox("لطفا پسورد را وارد کنید", , "خطا")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
    End Sub
    Private Function CUN()
        Dim re As RegistryKey
        re = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall", RegistryKeyPermissionCheck.ReadWriteSubTree)
        re.CreateSubKey("{927BF06D-DE19-4159-AC66-EDB924A6015D}", RegistryKeyPermissionCheck.ReadWriteSubTree)
        re.SetValue("AuthorizedCDFPrefix", "", RegistryValueKind.String)
        re.SetValue("Comments", "", RegistryValueKind.String)
        re.SetValue("Contact", "BaR86", RegistryValueKind.String)
        re.SetValue("DisplayName", "AutoClose", RegistryValueKind.String)
        re.SetValue("DisplayVersion", "1.5.0", RegistryValueKind.String)
        re.SetValue("EstimatedSize", "130", RegistryValueKind.DWord)
        re.SetValue("HelpLink", "", RegistryValueKind.String)
        re.SetValue("HelpTelephone", "", RegistryValueKind.String)
        re.SetValue("InstallDate", "20121205", RegistryValueKind.String)
        re.SetValue("InstallLocation", "", RegistryValueKind.String)
        re.SetValue("InstallSource", "D:\AutoCloser\AutoClose\Debug\", RegistryValueKind.String)
        re.SetValue("Language", "409", RegistryValueKind.DWord)
        re.SetValue("ModifyPath", "MsiExec.exe /I{927BF06D-DE19-4159-AC66-EDB924A6015D}", RegistryValueKind.ExpandString)
        re.SetValue("Publisher", "BaR86", RegistryValueKind.String)
        re.SetValue("Readme", "", RegistryValueKind.String)
        re.SetValue("Size", "", RegistryValueKind.String)
        re.SetValue("UninstallString", "MsiExec.exe /I{927BF06D-DE19-4159-AC66-EDB924A6015D}", RegistryValueKind.ExpandString)
        re.SetValue("URLInfoAbout", "", RegistryValueKind.String)
        re.SetValue("URLUpdateInfo", "", RegistryValueKind.String)
        re.SetValue("Version", "1050000", RegistryValueKind.DWord)
        re.SetValue("VersionMajor", "1", RegistryValueKind.DWord)
        re.SetValue("VersionMinor", "5", RegistryValueKind.DWord)
        re.SetValue("WindowsInstaller", "1", RegistryValueKind.DWord)
        MsgBox("فعال شد")
        re.Close()


        Return 0
    End Function
    Private Sub Form3_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Form1.Enabled = True
        Form1.Focus()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            If TextBox2.Text <> "" Then
                If TextBox2.Text.GetHashCode = GetSetting("Atcr", "Startup", "pas", 0) Then
                    Form1.NotifyIcon1.Icon = Nothing
                    End

                Else
                    MsgBox("برای خروج احتیاج به پسورد صحیح دارید", , "خطا")
                End If
            Else
                MsgBox("لطفا پسورد را وارد کنید", , "خطا")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, , "خطای")
        End Try
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            If Button1.Visible Then
                Button1_Click(sender, e)
            ElseIf Button2.Visible Then
                Button2_Click(sender, e)
            End If
        End If
    End Sub
End Class