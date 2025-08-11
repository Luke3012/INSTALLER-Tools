Public Class installer
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            path.Text = FolderBrowserDialog1.SelectedPath
            GroupBox1.Text = "Primo STEP - Fatto"
            GroupBox2.Enabled = True
            Button2.Enabled = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        makeinstaller.Close()
        makeinstaller.ShowDialog()
    End Sub
End Class