Public Class namebackup
    Public done As Boolean
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub namebackup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = usercopy.ListBox1.SelectedItem
        Label2.Text = "Visto che quello di prima non ti è piaciuto."
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            My.Computer.FileSystem.RenameDirectory(Application.StartupPath & "\installertoolsconfig\backups\" & usercopy.ListBox1.SelectedItem, TextBox1.Text)
            done = True
            Close()
        Catch
            MsgBox("Errore durante la Rinominazione! Riprova!", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Label2.Text = "Ok, questo Nome potrebbe andar bene."
        Button1.Enabled = True
        For i As Integer = 0 To usercopy.ListBox1.Items.Count - 1
            If usercopy.ListBox1.Items(i).ToString = TextBox1.Text Then
                Button1.Enabled = False
                Label2.Text = "Questo Nome già esiste!"
            End If
        Next
        If Replace(TextBox1.Text, " ", "") = "" Then
            Button1.Enabled = False
            Label2.Text = "Il Campo di Testo è Vuoto!"
        ElseIf Replace(TextBox1.Text, " ", "") = usercopy.ListBox1.SelectedItem Then
            Button1.Enabled = False
            Label2.Text = "Hai inserito lo stesso Nome ma con degli spazi in più."
        End If
    End Sub
End Class