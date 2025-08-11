Imports System.IO
Imports System.Net

Public Class Inizio
    Dim config As String = Application.StartupPath & "\installertoolsconfig"
    Dim comment As String = "Migliorata stabilità e velocità durante la copia e Migliorata affidabilità"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = Environment.UserName
        TextBox2.Text = My.Computer.Info.OSFullName
        TextBox3.Text = My.Application.Info.Version.ToString
        'controlla se ci sono le cartelle preimpostate
        If Not Directory.Exists(config) Then
            Try
                Directory.CreateDirectory(config)
                Dim dirinfo As IO.DirectoryInfo = New IO.DirectoryInfo(config)
                dirinfo.Attributes = IO.FileAttributes.Hidden
            Catch ex As Exception
                MsgBox("Errore Salvataggio Configurazione!", MsgBoxStyle.Critical, "Errore!")
                Close()
            End Try
        End If

        checkupgrade()
        updatecheck()
    End Sub

    Public Async Sub updatecheck()
        If My.Computer.Network.IsAvailable = True Then
            Label5.Text = "Controllo aggiornamenti..."
            Try
                File.Delete(config & "\version.txt")
            Catch
            End Try
            Dim task As New Task(Sub()
                                     Try
                                         Dim client As New WebClient
                                         client.DownloadFile(New Uri("https://onedrive.live.com/download?cid=3781DC0B8F8FC809&resid=3781DC0B8F8FC809%2116957&authkey=APGRMgrVIRcn4uw"), config & "\version.txt")
                                     Catch
                                     End Try
                                 End Sub)
            task.Start()
            Await task

            Try
                Dim capiscoseaggiornamento As Integer = File.ReadAllText(config & "\version.txt")
                If Not capiscoseaggiornamento = TextBox3.Text Then
                    ' Vuol dire che ha trovato un Aggiornamento, quindi avvia la finestra di aggiornamento
                    updating.Show()
                    usercopy.Close()
                    installer.Close()
                    Close()
                Else
                    Label5.Text = "Nessun aggiornamento disponibile"
                End If
            Catch
                Label5.Text = "Errore controllo aggiornamenti"
            End Try
        End If
    End Sub

    Public Sub Button5_MouseLeave() Handles Button5.MouseLeave
        Label2.Font = New Font(Label2.Font, FontStyle.Regular)
    End Sub
    Public Sub Button5_MouseEnter() Handles Button5.MouseEnter
        Label2.Font = New Font(Label2.Font, FontStyle.Bold)
    End Sub

    Public Sub Button3_MouseLeave() Handles Button3.MouseLeave
        Label1.Font = New Font(Label1.Font, FontStyle.Regular)
    End Sub
    Public Sub Button3_MouseEnter() Handles Button3.MouseEnter
        Label1.Font = New Font(Label1.Font, FontStyle.Bold)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Informazioni.ShowDialog()
    End Sub

    Public Sub Button4_MouseLeave() Handles Button4.MouseLeave
        Button4.Font = New Font(Button4.Font, FontStyle.Regular)
    End Sub
    Public Sub Button4_MouseEnter() Handles Button4.MouseEnter
        Button4.Font = New Font(Button4.Font, FontStyle.Bold)
    End Sub

    Public Sub Button1_MouseLeave() Handles Button1.MouseLeave
        Button1.Font = New Font(Button1.Font, FontStyle.Regular)
    End Sub
    Public Sub Button1_MouseEnter() Handles Button1.MouseEnter
        Button1.Font = New Font(Button1.Font, FontStyle.Bold)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Hide()
        installer.Close()
        installer.ShowDialog()
        Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Hide()
        usercopy.Close()
        usercopy.ShowDialog()
        Show()
    End Sub

    Dim where As String = Application.StartupPath & "\installertoolsconfig\update.exe"
    Dim bat As String = Application.StartupPath & "\toolsupdater.exe"
    Dim wow As String = IO.Path.GetFileName(Application.ExecutablePath)
    Public Sub checkupgrade()
        If File.Exists(bat) Then
            File.Delete(bat)
            MsgBox("Novità:" & vbNewLine & comment, MsgBoxStyle.Information, "Aggiornamento Completato!")
        End If

        If Not File.Exists(where) Then
            Exit Sub
        End If

        Try
            File.WriteAllBytes(bat, My.Resources.toolsupdater)
            Process.Start(bat)
            Close()
        Catch
            MsgBox("Qualcosa è andato storto durante il processo di aggiornamento...", MsgBoxStyle.Critical, "Errore")
        End Try
    End Sub

    Private Sub fix_Click(sender As Object, e As EventArgs) Handles fix.Click
        Dim result2 As Integer = MsgBox("Vuoi Ri-Scaricare l'Ultima versione disponibile di INSTALLERtools? (Utile Se qualcosa è andato storto e/o serve la versione più aggiornata)", MsgBoxStyle.YesNo, "?")
        If result2 = MsgBoxResult.Yes Then
            updating.Show()
            Close()
        End If
    End Sub
End Class
