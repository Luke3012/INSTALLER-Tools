Imports System.Net
Imports System.IO
Public Class updating
    Dim config As String = Application.StartupPath & "\installertoolsconfig"
    Dim where As String = Application.StartupPath & "\installertoolsconfig\update.exe"

    Private Async Sub updating_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            File.Delete(where)
        Catch
        End Try
        Dim oh As Boolean
        Label1.Text = "Scarico l'aggiornamento..."
        Dim upgradelink As String = "https://onedrive.live.com/download?cid=3781DC0B8F8FC809&resid=3781DC0B8F8FC809%2135290&authkey=AKqDx23d-vw7sGY"
        Dim task As New Task(Sub()
                                 Try

                                     Dim client As WebClient = New WebClient
                                     client.DownloadFile(New Uri(upgradelink), where)
                                     Dim anfs As New IO.FileInfo(where)
                                     If anfs.Length < 1500000 Then
                                         MsgBox("Aggiornamento non riuscito.", MsgBoxStyle.Exclamation)
                                         Try
                                             File.Delete(where)
                                         Catch
                                         End Try
                                         oh = True
                                     End If
                                 Catch
                                     MsgBox("Aggiornamento non riuscito.", MsgBoxStyle.Exclamation)
                                     Try
                                         File.Delete(where)
                                     Catch
                                     End Try
                                     oh = True
                                 End Try
                             End Sub)
        task.Start()
        Await task

        If oh = True Then
            System.Windows.Forms.Application.Restart()
        End If
        Await dopo()
    End Sub

    Private Async Function dopo() As Task
        Dim checkl As Long = "0"
        Dim check As New Task(Sub()
                                  Try
                                      Dim obj As New WebClient
                                      Dim s As Stream
                                      s = obj.OpenRead(where)
                                      checkl = Long.Parse(obj.ResponseHeaders("Content-Length").ToString())
                                      obj.CancelAsync()
                                  Catch
                                      checkl = "0"
                                  End Try
                              End Sub)
        check.Start()
        Await check
        If Not checkl = "0" Then
            ' Adesso controlliamo se la grandezza del file generata da internet sia uguale a quella scaricata
            Dim anfs As New FileInfo(where)
            Dim size As Long = anfs.Length
            If Not size = checkl Then
                MsgBox("Aggiornamento non riuscito.", MsgBoxStyle.Exclamation)
                Try
                    File.Delete(where)
                Catch
                End Try
            End If
        End If
        System.Windows.Forms.Application.Restart()
    End Function
End Class