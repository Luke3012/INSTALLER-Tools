Imports System.IO
Public Class backrest
    Public restoremode As Boolean
    Public dove As String
    Public Desktop As String
    Public Documents As String
    Public Download As String
    Public Images As String
    Public Music As String
    Public Video As String
    Public Favorites As String
    Public principale As String
    Public unico As Boolean
    Public unicodove As String
    Public tempdove As String

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
                DeleteFilesFromFolder(_folder)
            Next
        End If
    End Sub

    Private Async Sub backrest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        errorscopy.Close()
        Timer3.Start()

        If Directory.Exists(dove) Or Directory.Exists(tempdove) Then
            wait.Show()
            Dim del As New Task(Sub()
                                    Try
                                        DeleteFilesFromFolder(tempdove)
                                        Directory.Delete(tempdove, True)
                                    Catch
                                    End Try
                                    If Not tempdove = dove Then
                                        Try
                                            DeleteFilesFromFolder(dove)
                                            Directory.Delete(dove, True)
                                        Catch
                                        End Try
                                    End If
                                End Sub)
            del.Start()
            Await del
            wait.Close()
        End If

        If Not Directory.Exists(dove) And Not unico = True Then Directory.CreateDirectory(dove)

        'Controlla se la Cartella non è quella di un utente
        If unico = True Then
            principale = principale.Substring(0, principale.Length - 1)
            list1.Hide()
            list2.Hide()
            list4.Hide()
            list5.Hide()
            list6.Hide()
            list7.Hide()
            list3.Text = "Copia in Corso ..."
            Await quantita(principale)
            totale.Text = "Dimensione Totale: " & tot.ToString("n") & " GB"
            ProgressBar2.Maximum = 100
            min = (tot * 1073741824) / 100

            des2file = unicodove & "\"
            alternativecopy()
            Exit Sub
        End If

        'Adesso stabilisce quanto sono grandi le cartelle
        Await quantita(Desktop)
        list1.Text = "Desktop - " & quan
        Await quantita(Documents)
        list2.Text = "Documenti - " & quan
        Await quantita(Download)
        list3.Text = "Download - " & quan
        Await quantita(Images)
        list4.Text = "Immagini - " & quan
        Await quantita(Music)
        list5.Text = "Musica - " & quan
        Await quantita(Video)
        list6.Text = "Video - " & quan
        Await quantita(Favorites)
        list7.Text = "Preferiti - " & quan
        totale.Text = "Dimensione Totale: " & tot.ToString("n") & " GB"
        min = (tot * 1073741824) / 100
        ProgressBar2.Maximum = 100


        'Andiamo a copiar
        des2file = dove & "\"
        copy()
    End Sub


    Dim vedere As Boolean
    Dim contare As Integer = 0
    Dim counter2 As Integer
    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        contare = contare + 1
        If contare = 1 Then
            Label3.Text = ".. "
        End If
        If contare = 2 Then
            Label3.Text = ".  "
        End If
        If contare = 3 Then
            Label3.Text = "  "
        End If
        If contare = 4 Then
            Label3.Text = ".  "
        End If
        If contare = 5 Then
            Label3.Text = ".. "
        End If
        If contare = 6 Then
            Label3.Text = "..."
        End If
        If contare = 7 Then
            Label3.Text = " .."
        End If
        If contare = 8 Then
            Label3.Text = "  ."
        End If
        If contare = 9 Then
            Label3.Text = "   "
        End If
        If contare = 10 Then
            Label3.Text = ".  "
        End If
        If contare = 11 Then
            Label3.Text = ".. "
        End If
        If contare = 12 Then
            Label3.Text = "..."
            contare = 0
        End If

        If vedere = True Then
            If Not already = False Or annulla = True Then
                Exit Sub
            End If
            already = True
            copystat.Text = "Copio File " & counter2 & " di " & massimo & " ..."
            Try
                ProgressBar1.Value = counter2
            Catch
                ProgressBar1.Value = 0
            End Try

            Try
                ProgressBar2.Value = percentuale
                stato.Text = "Avanzamento Totale : " & percentuale & " %"
            Catch
            End Try
            Try
                copygb.Text = "Grandezza Totale File Copiati: " & curgb.ToString("n") & " GB"
            Catch
            End Try

            numerror.Text = cerror
            Try
                If Not currentname = "" Then
                    nomefile.Text = currentname
                    dimfile.Text = currentdim
                Else
                    nomefile.Text = "Calcolo ..."
                    dimfile.Text = "Ottengo Informazioni ..."
                End If
            Catch
                nomefile.Text = "Calcolo ..."
                dimfile.Text = "Ottengo Informazioni ..."
            End Try

            already = False
        End If

        If annulla = True Then
            stato.Text = "Annullamento in Corso"
        End If
    End Sub

    Dim already As Boolean
    Public quan As String
    Dim tot As Double = 0
    Private Async Function quantita(ByVal curdir As String) As Task
        Dim task As New Task(Sub()
                                 Try
                                     Dim drInfo As New DirectoryInfo(curdir)
                                     sizetemp = 0
                                     quantita2(curdir)
                                 Catch
                                     quan = "Errore"
                                     'MsgBox("La Cartella " & "'" & curdir & "' non esiste!", MsgBoxStyle.Critical, "Cartella non esistente!")
                                     lst.Add(curdir)
                                     Errors = True
                                     cerror = cerror + 1
                                 End Try
                             End Sub)
        task.Start()
        Await task
    End Function

    Dim sizetemp As Long
    Dim sef As Boolean
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

        Dim num As Double = sizetemp / 1048576
        quan = num.ToString("n")
        Dim temp As Double = fileSize / 1073741824
        tot = tot + temp
        If num >= 1024 Then
            num = sizetemp / 1073741824
            quan = num.ToString("n") & " GB"
        Else
            quan = quan & " MB"
        End If
    End Sub


    Dim filecount As Integer
    Dim desfile As String
    Dim des2file As String
    Dim massimo As Integer
    Dim di As DirectoryInfo
    Public annulla As Boolean = False
    Private Async Sub copy()
        Try
            'Abilita il Pulsante per Annullare
            annullo.Enabled = True

            'Desktop
            desfile = Desktop
            di = New DirectoryInfo(desfile)
            list1.Font = New Font(list1.Font, FontStyle.Bold)
            filecount = 0
            Await CountFiles(desfile, filecount)
            copystat.Text = "Copio File 0 di " & filecount.ToString & " ..."
            Await copying(desfile, des2file & di.Name)
            list1.Font = New Font(list1.Font, FontStyle.Regular)

            'Documenti
            desfile = Documents
            di = New DirectoryInfo(desfile)
            list2.Font = New Font(list2.Font, FontStyle.Bold)
            filecount = 0
            Await CountFiles(desfile, filecount)
            copystat.Text = "Copio File 0 di " & filecount.ToString & " ..."
            Await copying(desfile, des2file & di.Name)
            list2.Font = New Font(list2.Font, FontStyle.Regular)

            'Download
            desfile = Download
            di = New DirectoryInfo(desfile)
            list3.Font = New Font(list3.Font, FontStyle.Bold)
            filecount = 0
            Await CountFiles(desfile, filecount)
            copystat.Text = "Copio File 0 di " & filecount.ToString & " ..."
            Await copying(desfile, des2file & di.Name)
            list3.Font = New Font(list3.Font, FontStyle.Regular)

            'Immagini
            desfile = Images
            di = New DirectoryInfo(desfile)
            list4.Font = New Font(list4.Font, FontStyle.Bold)
            filecount = 0
            Await CountFiles(desfile, filecount)
            copystat.Text = "Copio File 0 di " & filecount.ToString & " ..."
            Await copying(desfile, des2file & di.Name)
            list4.Font = New Font(list4.Font, FontStyle.Regular)

            'Musica
            desfile = Music
            di = New DirectoryInfo(desfile)
            list5.Font = New Font(list5.Font, FontStyle.Bold)
            filecount = 0
            Await CountFiles(desfile, filecount)
            copystat.Text = "Copio File 0 di " & filecount.ToString & " ..."
            Await copying(desfile, des2file & di.Name)
            list5.Font = New Font(list5.Font, FontStyle.Regular)

            'Video
            desfile = Video
            di = New DirectoryInfo(desfile)
            list6.Font = New Font(list6.Font, FontStyle.Bold)
            filecount = 0
            Await CountFiles(desfile, filecount)
            copystat.Text = "Copio File 0 di " & filecount.ToString & " ..."
            Await copying(desfile, des2file & di.Name)
            list6.Font = New Font(list6.Font, FontStyle.Regular)

            'Preferiti
            desfile = Favorites
            di = New DirectoryInfo(desfile)
            list7.Font = New Font(list7.Font, FontStyle.Bold)
            filecount = 0
            Await CountFiles(desfile, filecount)
            copystat.Text = "Copio File 0 di " & filecount.ToString & " ..."
            Await copying(desfile, des2file & di.Name)
            list7.Font = New Font(list7.Font, FontStyle.Regular)

            'Disabilita il Pulsante per Annullare
            annullo.Enabled = False

            'Finito
            ProgressBar2.Value = ProgressBar2.Maximum
            If annulla = True Then
                stato.Text = "Annullamento in Corso"
                copystat.Text = "Annullo ..."
                copygb.Text = "Annullo ..."
            Else
                copystat.Text = "Tutti i File sono stati Copiati!"
            End If

            done()
        Catch
            MsgBox("Errore COPIA! Hai per caso scollegato l'HardDisk / USB senza il mio consenso eh? Birichino.", MsgBoxStyle.Critical, "Cosa hai combinato?")
            Close()
        End Try
    End Sub

    Private Async Sub alternativecopy()
        Try
            'Abilita il Pulsante per Annullare
            annullo.Enabled = True

            'Copia
            desfile = principale
            di = New DirectoryInfo(desfile)
            list3.Font = New Font(list3.Font, FontStyle.Bold)
            filecount = 0
            Await CountFiles(desfile, filecount)
            copystat.Text = "Copio File 0 di " & filecount.ToString & " ..."
            Await copying(desfile, des2file & "temp" & di.Name)
            list3.Font = New Font(list3.Font, FontStyle.Regular)

            'Disabilita il Pulsante per Annullare
            annullo.Enabled = False

            'Finito
            list3.Text = "Copia Effettuata!"
            ProgressBar2.Value = ProgressBar2.Maximum
            If annulla = True Then
                stato.Text = "Annullamento in Corso"
                copystat.Text = "Annullo ..."
                copygb.Text = "Annullo ..."
            Else
                copystat.Text = "Tutti i File sono stati Copiati!"
            End If

            done()
        Catch
            MsgBox("Errore COPIA! Hai per caso scollegato l'HardDisk / USB senza il mio consenso eh? Birichino.", MsgBoxStyle.Critical, "Cosa hai combinato?")
            Close()
        End Try
    End Sub

    Dim iferror As Boolean
    Dim counter As Integer
    Private Async Function CountFiles(InFolder As String, ByVal Result As Integer) As Task
        If annulla = True Then
            stato.Text = "Annullamento in Corso"
            Exit Function
        End If

        iferror = False
        vedere = False
        Result = 0

        Dim task As New Task(Sub()
                                 Try
                                     tempcounter = 0
                                     counttot(InFolder)
                                 Catch
                                 End Try
                             End Sub)
        task.Start()
        Await task
        Result = counter
        massimo = counter
        ProgressBar1.Value = 0
        counter2 = 0
        ProgressBar1.Maximum = counter
    End Function

    Dim tempcounter As Integer
    Private Sub counttot(ByVal sourcefolder As String)
        If annulla = True Then
            Exit Sub
        End If

        counter = Directory.GetFiles(sourcefolder, "*.*").Length
        tempcounter += counter


        Dim folders As String() = Directory.GetDirectories(sourcefolder)
        For Each folder As String In folders
            If annulla = True Then
                Exit For
            End If
            Try
                Dim name As String = Path.GetFileName(folder)
                counttot(folder)
            Catch
            End Try
        Next

        counter = tempcounter
    End Sub

    Dim Errors As Boolean
    Public cerror As String = 0
    Private Async Function copying(ByVal source As String, ByVal copyto As String) As Task
        If annulla = True Then
            stato.Text = "Annullamento in Corso"
            Exit Function
        End If

        currentname = ""
        vedere = True
        Dim ct As New Task(Sub()
                               Try
                                   CopyFolder(source, copyto)
                               Catch
                               End Try
                           End Sub)
        ct.Start()
        Await ct
        currentname = ""

    End Function

    Dim curgb As Double = 0
    Public lst As List(Of String) = New List(Of String)
    Dim currentname As String = ""
    Dim currentdim As String = ""
    Public Sub CopyFolder(sourceFolder As String, destFolder As String)
        If annulla = True Then
            Exit Sub
        End If

        If Not Directory.Exists(destFolder) Then Directory.CreateDirectory(destFolder)
        Dim files As String() = Directory.GetFiles(sourceFolder)
        For Each file__1 As String In files
            If annulla = True Then
                Exit For
            End If
            Dim name As String = Path.GetFileName(file__1)
            If name <> "thumbs.db" Then
                Dim dest As String = Path.Combine(destFolder, name)
                counter2 += 1
                Try
                    Try
                        addname(file__1)
                    Catch
                    End Try
                    File.Copy(file__1, dest, True)
                    Try
                        addgb(dest)
                    Catch
                    End Try
                Catch
                    lst.Add(file__1)
                    Errors = True
                    cerror = cerror + 1
                End Try
            End If
        Next

        If annulla = True Then
            Exit Sub
        End If

        Dim folders As String() = Directory.GetDirectories(sourceFolder)
        For Each folder As String In folders
            If annulla = True Then
                Exit For
            End If
            Try
                Dim name As String = Path.GetFileName(folder)
                Dim dest As String = Path.Combine(destFolder, name)
                CopyFolder(folder, dest)
            Catch
                Try
                    Directory.Delete(folder, True)
                Catch
                End Try
            End Try
        Next
    End Sub

    Dim contgb As Long
    Dim percentage As Double
    Dim min As Double
    Dim percentuale As Double
    Private Sub addgb(filegb As String)
        Dim fi1 As New FileInfo(filegb)

        Dim temp As Double = fi1.Length / 1073741824
        curgb += temp

        Dim temp2 As Double = (curgb * 1073741824) / min
        percentuale = Math.Round(temp2, 0)
    End Sub
    Private Sub addname(filegb As String)
        Dim fi1 As New FileInfo(filegb)
        Dim temp As Double = fi1.Length / 1073741824

            Dim num As Double = fi1.Length / 1048576
        If num >= 1024 Then
            currentdim = temp.ToString("n") & " GB"
        Else
            currentdim = num.ToString("n") & " MB"
        End If

        currentname = fi1.Name
    End Sub

    Dim scritta As String = "Backup"
    Private Async Sub done()
        Timer3.Stop()
        ProgressBar1.Value = 0
        ProgressBar1.Maximum = 100
        ProgressBar1.Value = 100

        If Text = "Ripristino in Corso ..." Then
            scritta = "Ripristino"
        End If
        If iferror = True Or annulla = True Then
            If iferror = True Then
                MsgBox("Si è verificato un errore fatale durante la copia!", MsgBoxStyle.Critical, "Errore!")
            End If
            wait.Show()
                Dim del As New Task(Sub()
                                        Try
                                            DeleteFilesFromFolder(tempdove)
                                            Directory.Delete(tempdove, True)
                                        Catch
                                        End Try
                                        If Not tempdove = dove Then
                                            Try
                                                DeleteFilesFromFolder(dove)
                                                Directory.Delete(dove, True)
                                            Catch
                                            End Try
                                        End If
                                    End Sub)
                del.Start()
                Await del
            wait.Close()
            If annulla = True Then
                MsgBox("Annullato!", MsgBoxStyle.Information, "Fatto")
            End If

            Close()
                Exit Sub
            End If
        If Not Text = "Ripristino in Corso ..." Then
            If Not unico = True Then
                dove = unicodove
            End If
            Try
                Dim scrivi As New StreamWriter(tempdove & "\date.txt")
                scrivi.Write(Now.Date & " " & Now.Hour & ":" & Now.Minute)
                scrivi.Close()
            Catch
                MsgBox("Errore Salvataggio Data!", MsgBoxStyle.Critical, "Errore!")
            End Try
        End If

        If Not Errors = True Then
            MsgBox(scritta & " Effettuato con Successo!", MsgBoxStyle.Information, "Fatto!")
        Else
            copystat.Text = "Non Tutti i File sono stati copiati!"
            MsgBox(scritta & " Effettuato, ma ci sono stati " & cerror & " errori durante la copia!", MsgBoxStyle.Information, "Fatto!")
            errorscopy.ShowDialog()
        End If
        Close()
    End Sub

    Private Sub annullo_Click(sender As Object, e As EventArgs) Handles annullo.Click
        annulla = True
        stato.Text = "Annullamento in Corso"
        copystat.Text = "Annullo ..."
        totale.Text = "Attendi, Annullo ..."
        copygb.Text = "Annullo ..."
        nomefile.Text = "Annullo ..."
        dimfile.Text = "Annullo ..."
        annullo.Enabled = False
    End Sub
End Class