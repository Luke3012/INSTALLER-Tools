Imports System.IO
Public Class newbackup
    Dim pathh As String = Application.StartupPath & "\installertoolsconfig\backups"
    Dim user As String = "C:\Users\" & Environment.UserName & "\"
    Dim quando As String
    Dim dove As String
    Dim principale As String
    Private Sub newbackup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Text = "L'Utente Individuato e attualmente in uso è '" & Environment.UserName & "' ." ' & vbNewLine & "Se vuoi selezionare altro clicca su 'Cambia'."
        TextBox1.Text = Environment.UserName
        dove = pathh & "\" & Environment.UserName
        principale = "C:\Users\" & Environment.UserName & "\"
        principaletext.Text = principale
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            user = FolderBrowserDialog1.SelectedPath
            Dim di As New DirectoryInfo(user)
            Label2.Text = "L'Utente che hai selezionato è '" & di.Name & "' ." & vbNewLine & "Se vuoi selezionare altro clicca su 'Cambia'."
            TextBox1.Text = di.Name
            dove = pathh & "\" & di.Name
            principale = FolderBrowserDialog1.SelectedPath & "\"
            principaletext.Text = principale

            'Controllo più approfondito
            If Not Directory.Exists(principale & "Desktop") And Not Directory.Exists(principale & "Documents") Then
                Label2.Text = "Hai Selezionato la Cartella (Non Utente) '" & di.Name & "' ." & vbNewLine & "Se vuoi selezionare altro clicca su 'Cambia'."
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        backrest.Close()

        backrest.Favorites = principale & "Favorites"
        backrest.Desktop = principale & "Desktop"
        backrest.Download = principale & "Downloads"
        If Directory.Exists(principale & "Music") Then
            backrest.Music = principale & "Music"
        ElseIf Directory.Exists(principale & "OneDrive\Musica") Then
            backrest.Music = principale & "OneDrive\Musica"
        ElseIf Directory.Exists(principale & "OneDrive\Music") Then
            backrest.Music = principale & "OneDrive\Music"
        Else
            backrest.Music = principale & "Musica"
        End If
        If Directory.Exists(principale & "Documents") Then
            backrest.Documents = principale & "Documents"
        Else
            backrest.Documents = principale & "Documenti"
        End If
        backrest.Video = principale & "Videos"
        backrest.Images = principale & "Pictures"

        'Verifica se la cartella è una vera e propria cartella Utente
        If Not Directory.Exists(backrest.Desktop) And Not Directory.Exists(backrest.Documents) Then
            Dim result2 As Integer = MsgBox("La Cartella da te selezionata non sembra affatto essere una cartella Utente... (Almeno Credo). Salvo comunque la cartella e tutto il suo relativo contenuto?", MsgBoxStyle.YesNo, "Procedo Comunque?")
            If result2 = MsgBoxResult.Yes Then
                backrest.unico = True
                'dove = pathh
            Else
                Exit Sub
            End If
        End If

        backrest.dove = dove
        backrest.tempdove = dove
        backrest.principale = principale
        backrest.restoremode = False

        If Directory.Exists(dove) Then
            Dim result2 As Integer = MsgBox("Un Backup con lo stesso nome è stato già trovato! Vuoi sostituirlo col vecchio?", MsgBoxStyle.YesNo, "Sostituisco il Backup?")
            If result2 = MsgBoxResult.No Then
                TextBox1.SelectAll()
                Exit Sub
            End If
        End If

        backrest.Text = "Backup in Corso ..."

        Dim di As New DirectoryInfo(principale.Substring(0, principale.Length - 1))
        If backrest.unico = True Then
            backrest.unicodove = pathh
            backrest.tempdove = pathh & "\" & "temp" & di.Name
        End If
        backrest.ShowDialog()
        If backrest.unico = True Then
            Try
                Try
                    'Directory.Delete(dove)
                Catch
                End Try
                My.Computer.FileSystem.RenameDirectory(pathh & "\" & "temp" & di.Name, TextBox1.Text)
            Catch
            End Try
            Try
                File.Move(pathh & "\date.txt", pathh & "\" & TextBox1.Text & "\date.txt")
            Catch
            End Try
        End If
        Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = "" Then
            Button3.Enabled = False
        Else
            Button3.Enabled = True
            dove = pathh & "\" & TextBox1.Text
        End If
    End Sub
End Class