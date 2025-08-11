Imports System.Net
Imports System.IO
Imports System.IO.Compression

Public Class makeinstaller
    Public path As String = installer.path.Text & "\INSTALLER"
    Public iffond As Boolean
    Dim url As String = "https://onedrive.live.com/download?cid=3781DC0B8F8FC809&resid=3781DC0B8F8FC809%2128172&authkey=AAXzlAWDkHi557w"

    Private Sub makeinstaller_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If installer.config.Checked = True Then
            iffond = True
        Else
            iffond = False
            list2.Hide()
            list3.Hide()
        End If
        If My.Computer.Network.IsAvailable = True Then
            Try
                Directory.CreateDirectory(path)
            Catch
            End Try
            Download()
        Else
            MsgBox("Connessione ad Internet NON disponibile!", MsgBoxStyle.Critical, "Attenzione!")
            Close()
        End If
    End Sub

    Private Sub Progresso1(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)
        Try
            Dim bytesIn As Double = Double.Parse(e.BytesReceived.ToString())
            Dim totalBytes As Double = Double.Parse(e.TotalBytesToReceive.ToString())
            Dim percentage As Double = bytesIn / totalBytes * 100
            ProgressBar1.Value = Int32.Parse(Math.Truncate(percentage).ToString())
        Catch
        End Try
    End Sub

    Dim client1 As WebClient
    Private Sub Download()
        list.Font = New Font(list.Font, FontStyle.Bold)
        Try
            client1 = New WebClient
            AddHandler client1.DownloadProgressChanged, AddressOf Progresso1
            AddHandler client1.DownloadFileCompleted, AddressOf dopo
            client1.DownloadFileAsync(New Uri("https://onedrive.live.com/download?cid=3781DC0B8F8FC809&resid=3781DC0B8F8FC809%2135289&authkey=ABmK7ioD1tuXxLE"), path & "\INSTALLER.exe")
        Catch
            MsgBox("Errore Download!", MsgBoxStyle.Critical, "Errore!")
            Close()
        End Try
    End Sub

    Private Async Sub dopo()
        ProgressBar1.Value = 0
        If Directory.Exists(path & "\Fondamental") Then
            list.Text = "- Ripristino INSTALLER..."
            Dim eliminacartella As New Task(Sub()
                                                Try
                                                    Directory.Delete(path & "\Fondamental", True)
                                                Catch
                                                End Try
                                            End Sub)
            eliminacartella.Start()
            Await eliminacartella
        End If

        list.Font = New Font(list.Font, FontStyle.Regular)

        If Not iffond = True Then
            chiudi()
            Exit Sub
        End If

        list2.Font = New Font(list2.Font, FontStyle.Bold)
        Try
            Dim client As WebClient = New WebClient
            AddHandler client.DownloadProgressChanged, AddressOf Progresso1
            AddHandler client.DownloadFileCompleted, AddressOf extract
            client.DownloadFileAsync(New Uri(url), path & "\Fondamental.zip")
        Catch
            MsgBox("Errore Download Cartella FONDAMENTAL!", MsgBoxStyle.Critical, "Errore!")
            Close()
        End Try
    End Sub

    Dim fatto As Boolean
    Private Async Sub extract()
        list2.Font = New Font(list2.Font, FontStyle.Regular)
        list3.Font = New Font(list3.Font, FontStyle.Bold)
        ProgressBar1.Style = ProgressBarStyle.Marquee
        Dim estrazione As New Task(Sub()
                                       Dim zipPath As String = path & "\Fondamental.zip"
                                       Dim extractPath As String = path
                                       Try
                                           ZipFile.ExtractToDirectory(zipPath, extractPath)
                                           Dim checkupwrite1 As New StreamWriter(path & "\Fondamental\Settings\checkup.txt")
                                           checkupwrite1.WriteLine("true")
                                           checkupwrite1.Close()
                                           Dim checkupwrite2 As New StreamWriter(path & "\Fondamental\Settings\tool.txt")
                                           checkupwrite2.WriteLine("yes")
                                           checkupwrite2.Close()
                                           fatto = True
                                       Catch
                                           fatto = False
                                       End Try
                                       Try
                                           File.Delete(path & "\Fondamental.zip")
                                       Catch
                                       End Try
                                   End Sub)
        estrazione.Start()
        Await estrazione
        list3.Font = New Font(list3.Font, FontStyle.Regular)
        If fatto = True Then

            chiudi()
        Else
            MsgBox("Errore Estrazione Cartella FONDAMENTAL!", MsgBoxStyle.Critical, "Errore!")
            Close()
        End If
    End Sub


    Private Sub chiudi()
        MsgBox("Tutti i processi sono stati completati con successo!", MsgBoxStyle.Information, "Tutto Fatto!")
        Dim result As Integer = MsgBox("Vuoi avviare INSTALLER?", MsgBoxStyle.YesNo, "Avvio?")
        If result = MsgBoxResult.Yes Then
            Process.Start(path & "\INSTALLER.exe")
        End If

        Close()
        installer.Close()
    End Sub

End Class