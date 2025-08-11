Imports System.IO

Public Class usercopy
    Dim pathh As String = Application.StartupPath & "\installertoolsconfig\backups"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub usercopy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Crea Directory se non esiste
        If Not Directory.Exists(pathh) Then
            Directory.CreateDirectory(pathh)
            Dim dirinfo As IO.DirectoryInfo = New IO.DirectoryInfo(pathh)
            dirinfo.Attributes = IO.FileAttributes.Hidden
        End If

        foldercheck()
    End Sub

    Private Async Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim result As Integer = MsgBox("Sei sicuro/a di voler eliminare il Backup '" & ListBox1.SelectedItem & "' ?", MsgBoxStyle.YesNo, "Elimino?")
        If result = MsgBoxResult.Yes Then
            Dim bho As Boolean
            bho = False
            Enabled = False
            wait.Show()
            Dim cacca As String = ListBox1.SelectedItem
            Dim task As New Task(Sub()
                                     Try
                                         Dim sna As String = Application.StartupPath & "\installertoolsconfig\backups\" & cacca
                                         DeleteFilesFromFolder(sna)
                                         If Directory.Exists(sna) Then Directory.Delete(sna, True)
                                     Catch
                                         bho = True
                                     End Try
                                 End Sub)
            task.Start()
            Await task
            If bho = True Then
                MsgBox("Errore Eliminazione!", MsgBoxStyle.Critical, "Errore")
            End If
            Enabled = True
            wait.Close()
            foldercheck()
        End If
    End Sub

    Private Async Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedIndex = -1 Then
            Exit Sub
        Else
            Await vai()
        End If
    End Sub

    Private Async Function vai() As Task
        Dim selected As String = pathh & "\" & ListBox1.SelectedItem

        Try
            GroupBox2.Enabled = True
            Try
                quando.Text = File.ReadAllText(selected & "\date.txt")
            Catch
                quando.Text = "Errore caricamento..."
            End Try

            'Calcola dimensione
            Dim dir As String = pathh & "\" & ListBox1.SelectedItem
            quanto.Text = "Calcolo in Corso ..."
            Dim task As New Task(Sub()
                                     Try
                                         sizetemp = 0
                                         quan = ""
                                         quantita2(dir)
                                         Dim num As Double = sizetemp / 1073741824
                                         quan = num.ToString("n")
                                     Catch
                                         quan = "Errore"
                                     End Try
                                 End Sub)
            task.Start()
            Await task

            'Controlla se è stato selezionato altro
            If pathh & "\" & ListBox1.SelectedItem <> selected Then Exit Function

            If Not quan = "Errore" Then
                quanto.Text = quan & " GB"
                Button4.Enabled = True
                Button5.Enabled = True
            Else
                quanto.Text = "Errore!"
            End If

            'Verifica la tipologia
            Dim principale As String = pathh & "\" & ListBox1.SelectedItem & "\"
            backrest.Desktop = principale & "Desktop"
            If Directory.Exists(principale & "Documents") Then
                backrest.Documents = principale & "Documents"
            Else
                backrest.Documents = principale & "Documenti"
            End If
            If Not Directory.Exists(backrest.Desktop) And Not Directory.Exists(backrest.Documents) Then
                cosa.Text = "Backup Cartella"
            Else
                cosa.Text = "Backup Utente"
            End If
        Catch
            quando.Text = "Errore caricamento..."
            quanto.Text = "Errore caricamento..."
            cosa.Text = "Errore caricamento..."
            Button4.Enabled = False
            Button5.Enabled = False
        End Try

        Button2.Enabled = True
        Button6.Enabled = True
    End Function

    Dim sizetemp As Long
    Dim quan As String
    Private Sub quantita2(ByVal sourceFolder As String)
        Dim drInfo As New DirectoryInfo(sourceFolder)
        Dim filesInfo() As FileInfo = drInfo.GetFiles("*.*")
        Dim fileSize As Long = 0
        For Each fileInfo As FileInfo In filesInfo
            fileSize += fileInfo.Length
        Next
        sizetemp += fileSize


        Dim folders As String() = Directory.GetDirectories(sourceFolder)
        For Each folder As String In folders
            Try
                Dim name As String = Path.GetFileName(folder)
                quantita2(folder)
            Catch
            End Try
        Next
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim temp As String = ListBox1.SelectedItem
        newbackup.Close()
        newbackup.ShowDialog()
        foldercheck()
        ListBox1.SelectedItem = temp
    End Sub

    Public Sub foldercheck()
        quando.Text = "Seleziona qualcosa..."
        quanto.Text = "Seleziona qualcosa..."
        cosa.Text = "Seleziona qualcosa..."
        Button4.Enabled = False
        Button2.Enabled = False
        Button5.Enabled = False
        Button6.Enabled = False
        ListBox1.Items.Clear()

        Try
            For Each folder As String In System.IO.Directory.GetDirectories(pathh & "\")
                ListBox1.Items.Add(Path.GetFileName(folder))
            Next
        Catch
            Close()
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim result As Integer = MsgBox("Sei sicuro/a di voler ripristinare il Backup '" & ListBox1.SelectedItem & "' ? (Lo copierò sul Desktop)", MsgBoxStyle.YesNo, "Ripristino?")
        If result = MsgBoxResult.Yes Then

            Dim principale As String = pathh & "\" & ListBox1.SelectedItem & "\"
            Dim dove As String = "C:\Users\" & Environment.UserName & "\Desktop\Salvataggio Utente " & ListBox1.SelectedItem
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
                backrest.unico = True
                dove = "C:\Users\" & Environment.UserName & "\Desktop\Salvataggio " & ListBox1.SelectedItem
            End If

            backrest.dove = dove
            backrest.tempdove = dove
            backrest.principale = principale
            backrest.restoremode = True

            backrest.Text = "Ripristino in Corso ..."

            If backrest.unico = True Then
                backrest.unicodove = "C:\Users\" & Environment.UserName & "\Desktop"
                backrest.tempdove = "C:\Users\" & Environment.UserName & "\Desktop\" & ListBox1.SelectedItem
            End If
            backrest.ShowDialog()
            If backrest.unico = True Then
                Try
                    My.Computer.FileSystem.RenameDirectory("C:\Users\" & Environment.UserName & "\Desktop\temp" & ListBox1.SelectedItem, "Salvataggio " & ListBox1.SelectedItem)
                Catch
                End Try
            End If

            If Not backrest.annulla = True Then
                Try
                    File.Delete(dove & "\date.txt")
                Catch
                End Try
                Dim result2 As Integer = MsgBox("Vuoi eliminare il backup per salvare spazio?", MsgBoxStyle.YesNo, "Elimino il Backup?")
                If result2 = MsgBoxResult.Yes Then
                    delete()
                End If
            End If

        End If
    End Sub

    Private Async Sub delete()
        Dim bho As Boolean
        bho = False
        Enabled = False
        wait.Show()
        Dim cacca As String = ListBox1.SelectedItem
        Dim task As New Task(Sub()
                                 Try
                                     DeleteFilesFromFolder(Application.StartupPath & "\installertoolsconfig\backups\" & cacca)
                                     Directory.Delete(Application.StartupPath & "\installertoolsconfig\backups\" & cacca, True)
                                 Catch
                                     bho = True
                                 End Try
                             End Sub)
        task.Start()
        Await task
        If bho = True Then
            MsgBox("Errore Eliminazione!", MsgBoxStyle.Critical, "Errore")
        End If
        Enabled = True
        wait.Close()
        foldercheck()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            Process.Start(pathh & "\" & ListBox1.SelectedItem)
        Catch
            MsgBox("Errore!", MsgBoxStyle.Critical, "!")
        End Try
    End Sub

    Sub DeleteFilesFromFolder(Folder As String)
        If Directory.Exists(Folder) Then
            For Each _file As String In Directory.GetFiles(Folder)
                Try
                    File.Delete(_file)
                Catch
                    Dim oFileInfo As New FileInfo(_file)
                    If (oFileInfo.Attributes And FileAttributes.ReadOnly) > 0 Then
                        oFileInfo.Attributes = oFileInfo.Attributes Xor FileAttributes.ReadOnly
                        File.Delete(_file)
                    End If
                End Try
            Next
            For Each _folder As String In Directory.GetDirectories(Folder)
                Try
                    DeleteFilesFromFolder(_folder)
                Catch
                End Try
            Next
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        namebackup.Close()
        namebackup.ShowDialog()

        If namebackup.done = True Then
            Dim temp As String = namebackup.TextBox1.Text
            foldercheck()
            ListBox1.SelectedItem = temp
        End If
    End Sub
End Class